using Business.Abstract;
using DataAccess.Context;
using DataAccess.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Presentation.Controllers
{
    [Authorize]
    public class MessageController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IMessageService _messageService;
        private readonly BaseContext _context;

        public MessageController(UserManager<AppUser> userManager, IMessageService messageService, BaseContext context)
        {
            _userManager = userManager;
            _messageService = messageService;
            _context = context;
        }

        public async Task<IActionResult> Chats()
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserPhoto = user.ImageUrl;

            var messages = _messageService.GetMessagesByPhone(user.PhoneNumber);
            ViewBag.Messages = messages;
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> ChatDetails(int id)
        {
            var user = await _userManager.FindByNameAsync(User.Identity.Name);
            ViewBag.UserPhoto = user.ImageUrl;
            ViewBag.UserId = user.Id;

            var messages = _messageService.GetMessagesByPhone(user.PhoneNumber);
            ViewBag.Messages = messages;

            var sendMessage = _messageService.GetMessagesByReceiver(id, user.PhoneNumber);
            ViewBag.receiverName = sendMessage[0].ReceiverName;
            ViewBag.reveicerPhoto = sendMessage[0].AppUser.ImageUrl;
            ViewBag.receiverId = sendMessage[0].AppUserId;

            var incomingMessage = _messageService.GetMessagesBySender(user.PhoneNumber, user.Id);

            List<Message> listMessages = new List<Message>();
            listMessages.AddRange(sendMessage);
            listMessages.AddRange(incomingMessage);
            ViewBag.listMessages = listMessages.OrderBy(x => x.Date);
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateMessage(Message message)
        {
            Message newMessage = new Message();
            var sender = await _userManager.FindByEmailAsync(User.Identity.Name);

            var receiver = _context.Users.Where(x => x.PhoneNumber == message.ReceiverPhone).FirstOrDefault();
            newMessage.ReceiverName = receiver.Name + " " + receiver.Surname;
            newMessage.AppUserId = receiver.Id;

            newMessage.Content = message.Content;
            newMessage.SenderPhone = message.SenderPhone;
            newMessage.ReceiverPhone = message.ReceiverPhone;
            newMessage.Date = DateTime.Now;

            _messageService.Create(newMessage);
            return RedirectToAction("Chat", "Message");
        }

        [HttpPost]
        public async Task<IActionResult> SendMessage(int receiverId, string MessageContent)
        {
            Message newMessage = new Message();
            var sender = await _userManager.FindByNameAsync(User.Identity.Name);

            var receiver = _context.Users.Where(x => x.Id == receiverId).FirstOrDefault();
            newMessage.ReceiverName = receiver.Name + " " + receiver.Surname;
            newMessage.ReceiverPhone = receiver.PhoneNumber;

            newMessage.AppUserId = receiverId;
            newMessage.SenderPhone = sender.PhoneNumber;
            newMessage.Content = MessageContent;
            newMessage.Date = DateTime.Now;

            _messageService.Create(newMessage);
            return RedirectToAction("ChatDetails", new { @id = receiverId });
        }


    }
}
