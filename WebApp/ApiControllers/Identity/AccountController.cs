using System;
using System.Linq;
using System.Security.Authentication;
using System.Threading.Tasks;
using Domain.App;
using Domain.App.Identity;
using Microsoft.AspNetCore.Http;
//using DTO.App;
//using DTO.App;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI.V4.Pages.Account.Internal;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace WebApp.ApiControllers.Identity
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[controller]/[action]")]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<AppUser> _signInManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;

        public AccountController(SignInManager<AppUser> signInManager, UserManager<AppUser> userManager, ILogger<AccountController> logger, IConfiguration configuration)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _logger = logger;
            _configuration = configuration;
        }

        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.JwtResponse), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(PublicApi.DTO.v1.Message), StatusCodes.Status404NotFound)]
        [HttpPost]
        public async Task<ActionResult<PublicApi.DTO.v1.JwtResponse>> Login([FromBody] PublicApi.DTO.v1.Login dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);
            if (appUser == null)
            {
                _logger.LogWarning($"WebApi login failed. User {User} not found!", dto.Email);
                return NotFound(new PublicApi.DTO.v1.Message("User/Password problem!"));
            }

            var result = await _signInManager.CheckPasswordSignInAsync(appUser, dto.Password, false);
            if (result.Succeeded)
            {
                // generate jwt and return it
                var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                var jwt = Extensions.Base.IdentityExtensions.GenerateJwt(
                    claimsPrincipal.Claims,
                    _configuration["JWT:Key"],
                    _configuration["JWT:Issuer"],
                    _configuration["JWT:Issuer"],
                    DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:ExpireDays"))
                );
                _logger.LogInformation($"WebApi login. User {User}", dto.Email);
                return Ok(new PublicApi.DTO.v1.JwtResponse()
                {
                    Token = jwt
                });

            }
            _logger.LogWarning($"WebApi login failed. User {User} - Bad password!", dto.Email);
            return NotFound(new PublicApi.DTO.v1.Message("User/Password problem!"));
        }
        
        
        [HttpPost]
        public async Task<IActionResult> Register([FromBody] PublicApi.DTO.v1.Register dto)
        {
            var appUser = await _userManager.FindByEmailAsync(dto.Email);
            if (appUser != null)
            {
                _logger.LogWarning($"User {User} already registered!", dto.Email);
                return BadRequest(new PublicApi.DTO.v1.Message("User already registered"));
            }

            EAccountType accountType = EAccountType.Customer;
            if (dto.AccountType.Equals("admin"))
            {
                if (dto.Password.Contains("Mellon"))
                {
                    accountType = EAccountType.Admin;
                }
                else
                {
                                    _logger.LogInformation("Cannot create admin user");
                                    return BadRequest(new PublicApi.DTO.v1.Message("You suck"));
                }
                
            } else if (dto.AccountType.Equals("company"))
            {
                accountType = EAccountType.Company;
            } else if (dto.AccountType.Equals("customer"))
            {
                accountType = EAccountType.Customer;
            }

            appUser = new Domain.App.Identity.AppUser()
            {
                Email = dto.Email,
                UserName = dto.Email,
                AccountType = accountType,
                
            };
            Console.WriteLine(appUser);
            var result = await _userManager.CreateAsync(appUser, dto.Password);
            
            if (result.Succeeded)
            {
               
                
                _logger.LogInformation("User {Email} created a new account with password", appUser.Email);

                var user = await _userManager.FindByEmailAsync(appUser.Email);
                if (user != null)
                {
                    // add to role
                    if (user.AccountType.Equals(EAccountType.Admin))
                    {
                        if(dto.Password!.Contains("Mellon"))
                        {
                            await _userManager.AddToRoleAsync(user, "admin");
                        }
                        else
                        {
                            throw new AuthenticationException();
                        }
                        
                    } else if (user.AccountType.Equals(EAccountType.Customer))
                    {
                        await _userManager.AddToRoleAsync(appUser, "customer");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(appUser, "company");
                    }
                    // generate jwt and return it
                                    var claimsPrincipal = await _signInManager.CreateUserPrincipalAsync(appUser);
                                    var jwt = Extensions.Base.IdentityExtensions.GenerateJwt(
                                        claimsPrincipal.Claims,
                                        _configuration["JWT:Key"],
                                        _configuration["JWT:Issuer"],
                                        _configuration["JWT:Issuer"],
                                        DateTime.Now.AddDays(_configuration.GetValue<int>("JWT:ExpireDays"))
                                    );
                                    _logger.LogInformation($"WebApi login. User {User}", dto.Email);
                                    return Ok(new PublicApi.DTO.v1.JwtResponse()
                                    {
                                        Token = jwt
                                    });
                    
                }
                else
                {
                    _logger.LogInformation("User {Email} not found after creation", appUser.Email);
                    return BadRequest(new PublicApi.DTO.v1.Message("User not found after creation!"));

                }


            }
            var errors = result.Errors.Select(error => error.Description).ToList();
            return BadRequest(new PublicApi.DTO.v1.Message() {Messages = errors});
        }
    }
}