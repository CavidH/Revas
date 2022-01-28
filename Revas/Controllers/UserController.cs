using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Revas.Controllers
{
    public class UserController : Controller
    {
        private UserManager<AppUser> _userManager { get; }
        private SignInManager<AppUser> _signManager { get; }
        public UserController(SignInManager<AppUser> signManager, UserManager<AppUser> userManager)
        {
            _signManager = signManager;
            _userManager = userManager;
        }
        public IActionResult Index()
        {
            return View();
        }

    }
}
