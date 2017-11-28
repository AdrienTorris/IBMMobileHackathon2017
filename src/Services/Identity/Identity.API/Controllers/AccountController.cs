namespace IBM.Books.Identity.API.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using IBM.Books.Identity.API.Model;
    using Microsoft.AspNetCore.Authentication;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Logging;
    using IBM.Books.Identity.API.Services;
    using IBM.Books.Identity.API.ViewModels;
    using IBM.Books.Identity.API.Infrastructure.Helpers;

    [Route("api/v1/[controller]")]
    public class AccountController : Controller
    {
        private readonly ILoginService<ApplicationUser> _loginService;
        private readonly ILogger<AccountController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(
             ILoginService<ApplicationUser> loginService,
             ILogger<AccountController> logger,
             UserManager<ApplicationUser> userManager,
             SignInManager<ApplicationUser> signInManager)
        {
            _loginService = loginService;
            _logger = logger;
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<JsonResult> Login([FromBody]UserViewModel value)
        {
            if (value == null)
            {
                return new JsonResult(new APIResponseViewModel("ACC_001", "Les informations de connexion sont incorrectes"));
            }

            if (string.IsNullOrWhiteSpace(value.UserName) || string.IsNullOrWhiteSpace(value.Password))
            {
                return new JsonResult(new APIResponseViewModel("ACC_001", "Les informations de connexion sont incorrectes"));
            }

            if (!UserHelper.CheckUsernamePolicy(value.UserName))
            {
                return new JsonResult(new APIResponseViewModel("ACC_006", "Le nom d'utilisateur ne respecte pas la politique"));
            }

            var user = await _loginService.FindByUsername(value.UserName);
            if (user == null)
            {
                return new JsonResult(new APIResponseViewModel("ACC_002", "Impossible de récupérer les informations de l'utilisateur"));
            }

            //if (!await _loginService.ValidateCredentials(user, value.Password))
            //{
            //    return new JsonResult(new APIResponseViewModel("ACC_003", "Les informations de connexion sont incorrectes"));
            //}

            //await _loginService.SignIn(user);
            var result = await _signInManager.PasswordSignInAsync(user.UserName, value.Password, false, false);
            if (result.Succeeded)
            {
                return new JsonResult(new APIResponseViewModel("UserDetails", BuildUserDetailsViewModel(user)));
            }
            else if (result.RequiresTwoFactor)
            {

            }

            return new JsonResult(new APIResponseViewModel("ACC_011", "Impossible de connecter l'utilisateur"));
        }

        [HttpPost]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<JsonResult> Register([FromBody]UserViewModel value)
        {
            if (value == null)
            {
                return new JsonResult(new APIResponseViewModel("ACC_007", "Les informations sont incorrectes"));
            }

            if (string.IsNullOrWhiteSpace(value.UserName))
            {
                return new JsonResult(new APIResponseViewModel("ACC_004", "Le nom d'utilisateur est obligatoire"));
            }

            if (string.IsNullOrWhiteSpace(value.Password))
            {
                return new JsonResult(new APIResponseViewModel("ACC_005", "Le mot de passe est obligatoire"));
            }

            if (!UserHelper.CheckUsernamePolicy(value.UserName))
            {
                return new JsonResult(new APIResponseViewModel("ACC_006", "Le nom d'utilisateur ne respecte pas la politique"));
            }

            string mailConfirmationToken;
            ApplicationUser user;

            try
            {
                user = new ApplicationUser
                {
                    UserName = value.UserName,
                    Email = value.UserName,
                    LastName = value.LastName,
                    FirstName = value.FirstName
                };

                var result = await _userManager.CreateAsync(user, value.Password);
                if (result.Errors.Count() > 0)
                {
                    return new JsonResult(new APIResponseViewModel(result.Errors.First().Code, result.Errors.First().Description));
                }

                mailConfirmationToken = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                await _userManager.ConfirmEmailAsync(user, mailConfirmationToken);
                //var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);
                //var callbackUrl = Url.Action("ConfirmEmail", "Account", new { userId = user.Id, code = code });
                //// #TODO send mail

                return new JsonResult(new APIResponseViewModel("UserDetails", BuildUserDetailsViewModel(user)));
            }
            catch (Exception ex)
            {
                return new JsonResult(new APIResponseViewModel("ACC_010", "Une erreur est survenue"));
            }
            finally
            {
                mailConfirmationToken = null;
                user = null;
            }
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<JsonResult> GetById([FromQuery]int id)
        {
            if (id <= 0)
                return new JsonResult(new APIResponseViewModel("ACC_010", "You have to provide an identifier"));

            var user = await _userManager.FindByIdAsync(id.ToString());

            if (user != null && user.Id > 0)
                return new JsonResult(new APIResponseViewModel("UserDetails", BuildUserDetailsViewModel(user)));
            else
                return new JsonResult(new APIResponseViewModel());
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<JsonResult> GetByUsername([FromQuery]string username)
        {
            if (string.IsNullOrWhiteSpace(username))
                return new JsonResult(new APIResponseViewModel("ACC_008", "Username doesn't respect the username policy"));

            var user = await _userManager.FindByNameAsync(username);

            if (user != null && user.Id > 0)
                return new JsonResult(new APIResponseViewModel("UserDetails", BuildUserDetailsViewModel(user)));
            else
                return new JsonResult(new APIResponseViewModel());
        }

        [HttpGet]
        [Route("[action]")]
        [AllowAnonymous]
        public async Task<JsonResult> GetByEmail([FromQuery]string mail)
        {
            if (string.IsNullOrWhiteSpace(mail))
                return new JsonResult(new APIResponseViewModel("ACC_009", "Mail doesn't respect the mail policy"));

            var user = await _userManager.FindByEmailAsync(mail);

            if (user != null && user.Id > 0)
                return new JsonResult(new APIResponseViewModel("UserDetails", BuildUserDetailsViewModel(user)));
            else
                return new JsonResult(new APIResponseViewModel());
        }

        #region Internals

        private UserDetailsViewModel BuildUserDetailsViewModel(UserViewModel user)
        {
            return new UserDetailsViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        private UserDetailsViewModel BuildUserDetailsViewModel(ApplicationUser user)
        {
            return new UserDetailsViewModel
            {
                Id = user.Id,
                FirstName = user.FirstName,
                LastName = user.LastName,
                UserName = user.UserName,
                Email = user.Email
            };
        }

        #endregion Internals
    }
}