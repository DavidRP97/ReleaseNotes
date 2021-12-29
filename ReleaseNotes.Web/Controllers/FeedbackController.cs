using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Entities.Model.Consts;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.Feedback;
using ReleaseNotes.Web.Utils;
using System.Text.Json;
using X.PagedList;

namespace ReleaseNotes.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;
        private readonly IReleasePDVService _releasePDVService;
        private readonly IReleasePowerServerService _releasePowerServerService;

        public FeedbackController(IFeedbackService feedbackService, IReleasePDVService releasePDVService, IReleasePowerServerService releasePowerServerService)
        {
            _feedbackService = feedbackService;
            _releasePDVService = releasePDVService;
            _releasePowerServerService = releasePowerServerService;
        }

        [Authorize]
        public async Task<IActionResult> Index(int? pagina)
        {
            const int TotalPorPagina = 10;

            int NumeroPagina = (pagina ?? 1);

            var token = await HttpContext.GetTokenAsync("access_token");

            var feedbacks = await _feedbackService.FindAllFeedbacks(token);

            if (User.IsInRole(Role.Client))
            {
                string Email = User.Identity.IsAuthenticated ? User.Claims.FirstOrDefault(x => x.Type == "email").Value : string.Empty;

                return View(feedbacks.OrderByDescending(x => x.FeedbackId).Where(x => x.Email == Email).ToPagedList(NumeroPagina, TotalPorPagina));
            }

            return View(feedbacks.OrderByDescending(x => x.FeedbackId).ToPagedList(NumeroPagina, TotalPorPagina));

        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateFeedbackPositivePowerServer(long? id)
        {
            ViewBag.PowerServerId = id;
            ViewBag.From = FeedbackFrom.PowerServer;
            TempData["Feedback"] = JsonSerializer.Serialize(true);
            TempData["Controlador"] = JsonSerializer.Serialize("ReleasePowerServer");

            return View("CreateFeedback");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateFeedbackNegativePowerServer(long? id)
        {
            ViewBag.PowerServerId = id;
            ViewBag.From = FeedbackFrom.PowerServer;
            TempData["Feedback"] = JsonSerializer.Serialize(false);
            TempData["Controlador"] = JsonSerializer.Serialize("ReleasePowerServer");

            return View("CreateFeedback");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateFeedbackPositivePdv(long? id)
        {
            ViewBag.PdvId = id;
            ViewBag.From = FeedbackFrom.PDV;
            TempData["Feedback"] = JsonSerializer.Serialize(true);
            TempData["Controlador"] = JsonSerializer.Serialize("ReleasePDV");

            return View("CreateFeedback");
        }
        [Authorize]
        [HttpGet]
        public async Task<IActionResult> CreateFeedbackNegativePdv(long? noteId)
        {
            ViewBag.PdvId = noteId;
            ViewBag.From = FeedbackFrom.PDV;
            TempData["Feedback"] = JsonSerializer.Serialize(false);
            TempData["Controlador"] = JsonSerializer.Serialize("ReleasePDV");

            return View("CreateFeedback");
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateFeedback(FeedbackViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            model.FeedbackDate = DateTime.Now.ToString();
            model.FeedbackPositive = JsonSerializer.Deserialize<bool>(Convert.ToString(TempData["Feedback"]));

            var response = await _feedbackService.CreateFeedback(model, token);

            string controlador = JsonSerializer.Deserialize<string>(Convert.ToString(TempData["Controlador"]));

            if (response != null) return RedirectToAction("Index", $"{controlador}");

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult>Detail(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            ViewBag.Token = token;

            var feedbackDetail = await _feedbackService.FindFeedbackById(id, token);

            if (feedbackDetail.FeedbackFrom == Service.Utils.FeedbackFrom.PDV)
            {
                var pdv = await _releasePDVService.FindModuleById(feedbackDetail.ModulePdvId, token);
                var version = await _releasePDVService.FindReleaseById(pdv.ReleaseId, token);

                ViewBag.From = "PDV";
                ViewBag.VersionNumber = version.VersionNumber;
                ViewBag.ModuleName = pdv.ModuleName;
                ViewBag.Description = pdv.Notes;
            }

            if (feedbackDetail.FeedbackFrom == Service.Utils.FeedbackFrom.PowerServer)
            {
                var power = await _releasePowerServerService.FindModuleById(feedbackDetail.ModulePowerServerId, token);
                var version = await _releasePowerServerService.FindReleaseById(power.ReleaseId, token);

                ViewBag.From = "PDV";
                ViewBag.VersionNumber = version.VersionNumber;
                ViewBag.Title = power.Title;
                ViewBag.ModuleName = power.ModuleName;
                ViewBag.Description = power.Notes;
            }

            if (feedbackDetail != null) return View(feedbackDetail);

            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> DeleteFeedback(long id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var model = await _feedbackService.DeleteFeedback(id, token);

            if (model == true) return RedirectToAction(nameof(Index));
            return NotFound();
        }
    }
}
