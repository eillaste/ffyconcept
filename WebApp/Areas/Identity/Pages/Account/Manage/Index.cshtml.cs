using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Contracts.BLL.App;
using Contracts.DAL.App;
using DAL.App.EF;
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace WebApp.Areas.Identity.Pages.Account.Manage
{
    public partial class IndexModel : PageModel
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly AppDbContext _context;
        private readonly IAppUnitOfWork _uow;
        private readonly IAppBLL _bll;

        public IndexModel(
            UserManager<AppUser> userManager,
            SignInManager<AppUser> signInManager,

            IAppUnitOfWork uow, IAppBLL bll, AppDbContext context)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _uow = uow;
            _bll = bll;
            _context = context;
        }
        [Display(ResourceType = typeof(Resources.Views.Shared._Layout), Name = nameof(Username))]
        public string? Username { get; set; }

        [TempData]
        public string? StatusMessage { get; set; }

        [BindProperty]
        public InputModel? Input { get; set; }

        public class InputModel
        {
            [Phone]
            [Display(ResourceType = typeof(Resources.Views.Shared._Layout), Name = nameof(PhoneNumber))]
            public string? PhoneNumber { get; set; }
            
            
            [Display(ResourceType = typeof(Resources.Views.Shared._Layout), Name = nameof(Gender))]
            public EGender? Gender { get; set; }

        }

        private async Task LoadAsync(AppUser user)
        {
            var userName = await _userManager.GetUserNameAsync(user);
            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            //_userManager.AddToRoleAsync(user, )
            Username = userName;

            List<EGender?> list = new List<EGender?>();
            list.Add(EGender.Female);
            list.Add(EGender.Male);
            IEnumerable<EGender?> en = list;

            Console.WriteLine("EDITING");
            //ReturnUrl = returnUrl;
            //ExternalLogins = (await _signInManager.GetExternalAuthenticationSchemesAsync()).ToList();
            ViewData["Genders"] = new SelectList(en);
            
            Input = new InputModel
            {
                PhoneNumber = phoneNumber,
                Gender = EGender.Male
            };
        }

        public async Task<IActionResult> OnGetAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            await LoadAsync(user);
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound($"Unable to load user with ID '{_userManager.GetUserId(User)}'.");
            }

            if (!ModelState.IsValid)
            {
                await LoadAsync(user);
                return Page();
            }
            Console.WriteLine(Input!.Gender);
            var res = _context.AppUsers.FirstOrDefault(m => m.Id == user.Id);
            res!.Gender = (EGender) Input.Gender!;
            await _context.SaveChangesAsync();
            Console.WriteLine("ASDASDASD");
            Console.WriteLine(res!.Born);

            var phoneNumber = await _userManager.GetPhoneNumberAsync(user);
            if (Input!.PhoneNumber != phoneNumber)
            {
                var setPhoneResult = await _userManager.SetPhoneNumberAsync(user, Input.PhoneNumber);

                if (!setPhoneResult.Succeeded)
                {
                    StatusMessage = "Unexpected error when trying to set phone number.";
                    return RedirectToPage();
                }
            }

            await _signInManager.RefreshSignInAsync(user);
            StatusMessage = "Your profile has been updated";
            return RedirectToPage();
        }
    }
}
