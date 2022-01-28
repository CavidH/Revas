using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Revas.ViewModels;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Revas.Controllers
{
    public class AccountController : Controller
    {
        private UserManager<IdentityUser> _userManager { get; }
        private SignInManager<IdentityUser> _signManager { get; }
        public AccountController(SignInManager<IdentityUser> signManager, UserManager<IdentityUser> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(UserRegisterVM userregVM)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    Email = userregVM.Email,
                    UserName=userregVM.UserName,
                    EmailConfirmed = true,
                };
                var result = await _userManager.CreateAsync(user, userregVM.Password);
                if (result.Succeeded)
                {
                    return RedirectToAction("Login");
                }
                {
                    if (result.Errors.Count() > 0)
                    {
                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("message", error.Description);
                        }
                    }
                    return View(userregVM);
                }


            }
            return View(userregVM);
        }

        [HttpGet]
        public IActionResult Login()
        {
             return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(UserLoginVM userLogin ,string ReturnUrl)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByEmailAsync(userLogin.Email);
                if (user==null)
                {
                    ModelState.AddModelError("message", "Email not  found");
                    return View(userLogin);
                }
                if (await _userManager.CheckPasswordAsync(user, userLogin.Password) == false)
                {
                    ModelState.AddModelError("message", "Invalid credentials");
                    return View(userLogin);

                }
                var result = await _signManager.PasswordSignInAsync(user.UserName, userLogin.Password, userLogin.RememberMe, true);
                if (result.Succeeded)
                {
                    await _userManager.AddClaimAsync(user, new Claim("UserRole", "Admin"));
                    if (ReturnUrl!=null)
                                            {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("index","Home");
                }
                else
                {
                    ModelState.AddModelError(" ", "Invalid login attempt");
                    return View(userLogin);
                }
            }
            return View(userLogin);
        }

        public async Task<IActionResult> Logout()
        {
            await _signManager.SignOutAsync();
            return RedirectToAction("login", "account");
        }
    }
}
