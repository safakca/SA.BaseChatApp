using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Presentation.Models;

namespace Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly SignInManager<AppUser> _userManager;

        public LoginController(SignInManager<AppUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Index(UserSignInModel model)
        {
            var result = await _userManager.PasswordSignInAsync(model.UserName, model.Password, true, true);
            if (result.Succeeded)
                return RedirectToAction("Chats", "Message");
            return View();
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _userManager.SignOutAsync();
            return RedirectToAction("Index", "Login");
        }
    }
}
//myYilmaz MUS.tafa+99