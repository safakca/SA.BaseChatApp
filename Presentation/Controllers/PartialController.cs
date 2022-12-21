using Business.Abstract;
using DataAccess.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    public class PartialController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;

        public PartialController(UserManager<AppUser> userManager, IMessageService messageService)
        {
            _userManager = userManager;
            _messageService = messageService;
        }

        public IActionResult AddContactPartial()
        {
            return View();
        }
    }
}
