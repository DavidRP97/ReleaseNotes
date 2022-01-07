using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.Email;

namespace ReleaseNotes.Web.Controllers
{
    public class EmailController : Controller
    {
        private readonly IEmailService _emailService;

        public EmailController(IEmailService emailService)
        {
            _emailService = emailService ?? throw new ArgumentNullException(nameof(emailService));
        }

        [Authorize]
        public async Task<IActionResult> Index()
        {

            var token = await HttpContext.GetTokenAsync("access_token");
            var emailConfig = await _emailService.FindEmail(token);

            return View(emailConfig);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult> DeleteReceiver(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var receiver = await _emailService.DeleteReceiver(id, token);

            if (receiver == true) return RedirectToAction(nameof(Index));
            return View(receiver);

        }
        [HttpPost]
        [Authorize]
        public async Task<IActionResult> CreateReceiver(SenderEmailConfigViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            if (model.Email != null && model.Name != null)
            {
                var receiver = new ReceiverViewModel
                {
                    Name = model.Name,
                    Email = model.Email,
                    SenderEmailConfigId = model.SenderConfigId
                };

                var response = await _emailService.CreateReceiver(receiver, token);

                if (response != null) return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
