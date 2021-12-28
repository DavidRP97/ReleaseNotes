using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Entities.Model.Consts;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.Feedback;
using System.Text.Json;
using X.PagedList;

namespace ReleaseNotes.Web.Controllers
{
    public class FeedbackController : Controller
    {
        private readonly IFeedbackService _feedbackService;

        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }

        public async Task<IActionResult> Index(int? pagina)
        {
            const int TotalPorPagina = 10;

            int NumeroPagina = (pagina ?? 1);

            var token = await HttpContext.GetTokenAsync("access_token");

            var feedbacks = await _feedbackService.FindAllFeedbacks(token);

            return View(feedbacks.OrderByDescending(x => x.FeedbackId).ToPagedList(NumeroPagina, TotalPorPagina));
        }

        [HttpGet]
        public async Task<IActionResult> CreateFeedbackPositivePdv(long? id)
        {
            ViewBag.PdvId = id;
            ViewBag.From = FeedbackFrom.PDV;
            TempData["Feedback"] = JsonSerializer.Serialize(true);

            return View("CreateFeedback");
        }

        [HttpPost]
        public async Task<IActionResult> CreateFeedback(FeedbackViewModel model)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            model.FeedbackDate = DateTime.Now.ToString();
            model.FeedbackPositive = JsonSerializer.Deserialize<bool>(Convert.ToString(TempData["Feedback"]));

            var response = await _feedbackService.CreateFeedback(model, token);

            long? responseId = response.ModulePdvId == 0 ? response.ModulePowerServerId : response.ModulePdvId;

            if (response != null) return RedirectToAction("Index", "ReleasePDV", new { id = responseId });

            return View(model);
        }
    }
}
