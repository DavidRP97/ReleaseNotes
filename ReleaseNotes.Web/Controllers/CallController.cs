using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.Call;
using ReleaseNotes.Service.Models.Email;
using ReleaseNotes.Web.Utils;
using System.Text.Json;
using X.PagedList;

namespace ReleaseNotes.Web.Controllers
{
    public class CallController : Controller
    {
        private readonly IReleasePDVService _releasePDVService; 
        private readonly IReleasePowerServerService _releasePowerServerService; 
        private readonly IFeedbackService _feedbackService;
        private readonly IEmailService _emailService;
        private readonly IEmailSender _emailSender;
        private readonly ICallService _callService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public readonly IConfiguration _configuration;
        public CallController(ICallService callService, IWebHostEnvironment webHostEnvironment, 
            IEmailSender emailSender, IConfiguration configuration, IEmailService emailService,
            IFeedbackService feedbackService, IReleasePowerServerService releasePowerServerService, 
            IReleasePDVService releasePDVService)
        {
            _releasePDVService = releasePDVService;
            _releasePowerServerService = releasePowerServerService;
            _feedbackService = feedbackService;
            _emailService = emailService;
            _configuration = configuration; 
            _callService = callService;
            _webHostEnvironment = webHostEnvironment;
            _emailSender = emailSender;
        }
        public async Task<IActionResult> CreateFromFeedback(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var feedback = await _feedbackService.FindFeedbackById(id, token);

            var moduleId = feedback.FeedbackFrom == Service.Utils.FeedbackFrom.PDV ? feedback.ModulePdvId : feedback.ModulePowerServerId;

            string Detail = string.Empty;

            if (feedback.FeedbackFrom == Service.Utils.FeedbackFrom.PDV)
            {                
                var pdv = await _releasePDVService.FindModuleById(moduleId, token);
                var release = await _releasePDVService.FindReleaseById(pdv.ReleaseId, token);
                Detail = $"{pdv.ModuleName} / {pdv.Title} / Versão: {release.VersionNumber}";
            }
            else
            {
                var powerServer = await _releasePowerServerService.FindModuleById(moduleId, token);
                var release = await _releasePowerServerService.FindReleaseById(powerServer.ReleaseId, token);
                Detail = $"{powerServer.ModuleName} / {powerServer.Title} / Versão: {release.VersionNumber}";
            }

            ViewBag.Date = DateTime.Now.ToString();
            ViewBag.FeedbackId = id;
            ViewBag.Detail = Detail;
            return View("Create");
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.FeedbackId = null;
            ViewBag.Date = DateTime.Now.ToString();
            return View();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CallViewModel model, IFormFile image)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            if (image != null)
            {
                string directoryFolder = Path.Combine(_webHostEnvironment.WebRootPath, "ImagensAnexas");
                string imageName = Guid.NewGuid().ToString() + image.FileName + model.UserName;

                using (FileStream fs = new FileStream(Path.Combine(directoryFolder, imageName), FileMode.Create))
                {
                    await image.CopyToAsync(fs);
                    model.Imagem = "~/ImagensAnexas/" + imageName;
                }
            }

            var response = await _callService.CreateCall(model, token);

            var emailResponse = await _emailService.FindEmail(token);

            if (response != null)
            {
                string apiKey = _configuration["EmailApi:Key"];

                var To = new List<SendSmtpEmailTo>();

                var Sender = new SendSmtpEmailSender
                {
                    SenderEmail = emailResponse.Sender.Email,
                    SenderName = emailResponse.Sender.Name
                };

                foreach (var item in emailResponse.Receivers)
                {
                    To.Add(new SendSmtpEmailTo
                    {
                        ToEmail = item.Email,
                        ToName = item.Name
                    });
                }

                NewCallOpenedEmail email = new NewCallOpenedEmail
                {
                    Content = $"Chamado Aberto Por: {response.UserName}<br/>Assunto: {response.Subject}<br/>Conteúdo: {response.Detail}",
                    EmailSender = Sender,
                    SendSmtpEmailTo = To,
                    Subject = $"ATENÇÃO!!! Novo Chamado Aberto Para: {response.UserName}",
                };

                var emailSend = await _emailSender.SendEmail(email, apiKey);

                return RedirectToAction(nameof(Index));
            }


            return View(response);
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pagina)
        {
            
            const int TotalPorPagina = 10;

            int NumeroPagina = (pagina ?? 1);

            var token = await HttpContext.GetTokenAsync("access_token");

            var response = await _callService.FindAllCalls(token);

            if (User.IsInRole(Role.Client))
            {
                string Email = User.Identity.IsAuthenticated ? User.Claims.FirstOrDefault(x => x.Type == "email").Value : string.Empty;

                return View(response.OrderByDescending(x => x.DateToDatetime).Where(x => x.Email == Email).ToPagedList(NumeroPagina, TotalPorPagina));
            }

            return View(response.OrderByDescending(x => x.DateToDatetime).Where(x => x.Status != Service.Utils.Status.Resolved).ToPagedList(NumeroPagina, TotalPorPagina));

        }
        public async Task<IActionResult> Update(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _callService.FindCallById(id, token);
            TempData["Call"] = JsonSerializer.Serialize(model);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(CallViewModel model)
        {
            CallViewModel callViewModel = JsonSerializer.Deserialize<CallViewModel>(TempData["Call"].ToString());

            model.Date = callViewModel.Date;
            model.Detail = callViewModel.Detail;
            model.Email = callViewModel.Email;
            model.FeedbackId = callViewModel.FeedbackId;
            model.IsUrgent = callViewModel.IsUrgent;
            model.Software = callViewModel.Software;
            model.UserName = callViewModel.UserName;
            model.Imagem = callViewModel.Imagem;
            model.Subject = callViewModel.Subject;

            var token = await HttpContext.GetTokenAsync("access_token");
            var response = await _callService.UpdateCall(model, token);
            if (response != null) return RedirectToAction(
                 nameof(Index));
            return View(model);
        }
    }
}
