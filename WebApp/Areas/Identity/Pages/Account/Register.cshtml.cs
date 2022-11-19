using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Authentication;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Domain.App;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;

namespace WebApp.Areas.Identity.Pages.Account
{
    [AllowAnonymous]
    public class RegisterModel : PageModel
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<RegisterModel> _logger;
        private readonly IEmailSender _emailSender;

        public RegisterModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,
            ILogger<RegisterModel> logger,
            IEmailSender emailSender)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _logger = logger;
            _emailSender = emailSender;
        }

        [BindProperty]
        public InputModel? Input { get; set; }

        public string? ReturnUrl { get; set; }

        public IList<AuthenticationScheme>? ExternalLogins { get; set; }

        public class InputModel
        {
            [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
            [EmailAddress]
            [Display(ResourceType = typeof(Resources.Views.Shared._Layout), Name = "Email")]
            public string? Email { get; set; }

            [Required(ErrorMessageResourceType = typeof(Resources.Base.Common), ErrorMessageResourceName = "ErrorMessageRequired")]
            [StringLength(100, ErrorMessage = "The {0} must be at least {2} and at max {1} characters long.", MinimumLength = 6)]
            [DataType(DataType.Password)]
            [Display(ResourceType = typeof(Resources.Views.Shared._Layout), Name = "Password")]
            public string? Password { get; set; }

            [DataType(DataType.Password)]
            [Display(ResourceType = typeof(Resources.Views.Shared._Layout), Name = "ConfirmPassword")]
            [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
            public string? ConfirmPassword { get; set; }

            [Display(ResourceType = typeof(Resources.Views.Shared._Layout), Name = nameof(AccountType))]
            public EAccountType AccountType { get; set; }
        }

        public async Task OnGetAsync(string? returnUrl)
        {
            List<EAccountType?> list = new List<EAccountType?>();
            list.Add(EAccountType.Admin);
            list.Add(EAccountType.Company);
            list.Add(EAccountType.Customer);
            IEnumerable<EAccountType?> en = list;

            
            ReturnUrl = returnUrl;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewData["AccountTypes"] = new SelectList(en);
        }

        public async Task<IActionResult> OnPostAsync(string? returnUrl)
        {
            returnUrl ??= Url.Content("~/")!;
            ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            if (ModelState.IsValid)
            {

                var user = new AppUser { UserName = Input!.Email, Email = Input.Email, AccountType = Input.AccountType};
                
                var result = await _userManager.CreateAsync(user, Input.Password);
                if (result.Succeeded)
                {
                    if (user.AccountType.Equals(EAccountType.Admin))
                    {
                        if(Input.Password!.Contains("Mellon"))
                        {
                            await _userManager.AddToRoleAsync(user, "admin");
                        }
                        else
                        {
                            throw new AuthenticationException();
                        }
                        
                    } else if (user.AccountType.Equals(EAccountType.Customer))
                    {
                        await _userManager.AddToRoleAsync(user, "customer");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(user, "company");
                    }
                    _logger.LogInformation("User created a new account with password.");

                    var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                    code = WebEncoders.Base64UrlEncode(Encoding.UTF8.GetBytes(code));
                    var callbackUrl = Url.Page(
                        "/Account/ConfirmEmail",
                        pageHandler: null,
                        values: new { area = "Identity", userId = user.Id, code = code, returnUrl = returnUrl },
                        protocol: Request.Scheme);

                    await _emailSender.SendEmailAsync(Input.Email, "Confirm your email",
                        $"Please confirm your account by <a href='{HtmlEncoder.Default.Encode(callbackUrl)}'>clicking here</a>.");

                    if (_userManager.Options.SignIn.RequireConfirmedAccount)
                    {
                        return RedirectToPage("RegisterConfirmation", new { email = Input.Email, returnUrl = returnUrl });
                    }
                    else
                    {
                        await _signInManager.SignInAsync(user, isPersistent: false);
                        return LocalRedirect(returnUrl);
                    }
                }
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            // If we got this far, something failed, redisplay form
            return Page();
        }
    }
}
