using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using StudentenHuis.Models;
using StudentenHuis.Models.ViewModels;
namespace StudentenHuis.Controllers
{
    [Authorize]
    public class AccountController : Controller
    {
        private UserManager<ApplicationUser> UserManager;
        private SignInManager<ApplicationUser> signInManager;
        private IUserRepository UserRepository;
        public AccountController(UserManager<ApplicationUser> userMgr, SignInManager<ApplicationUser> signInMgr, IUserRepository UserRepository)
        {
            UserManager = userMgr;
            signInManager = signInMgr;
            this.UserRepository = UserRepository;
        }

        // Lijst aan gebruikers
        [Authorize]
        public ViewResult Index()
        {
            return View(UserRepository.Users);
        }

        // Inloggen
        [AllowAnonymous]
        public ViewResult Login(string returnUrl)
        {
            return View(new LoginModel
            {
                ReturnUrl = returnUrl
            });
        }
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel loginModel)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user =
                await UserManager.FindByNameAsync(loginModel.Name);
            if (user != null)
                {
                    await signInManager.SignOutAsync();
                    if ((await signInManager.PasswordSignInAsync(user,
                    loginModel.Password, false, false)).Succeeded)
                    {
                        return Redirect(loginModel?.ReturnUrl ?? "/Home");
                    }
                }
            }
            ModelState.AddModelError("", "Invalid name or password");
            return View(loginModel);
        }
        public async Task<RedirectResult> Logout(string returnUrl = "/")
        {
            await signInManager.SignOutAsync();
            return Redirect(returnUrl);
        }
[HttpGet]
        [AllowAnonymous]
        public IActionResult Register(string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;
            if (ModelState.IsValid)
            {
                var user = new ApplicationUser {
                    UserName = model.UserName,
                    Email = model.Email,
                    Firstname = model.Firstname,
                    Middlename = model.Middlename,
                    Lastname = model.Lastname,
                    PhoneNumber = model.Phonenumber
                };
                var result = await UserManager.CreateAsync(user, model.Password);
                if (result.Succeeded)
                {
                    return Redirect("/");
                }
            }

            // If we got this far, something failed, redisplay form
            return View(model);
        }
    }
}