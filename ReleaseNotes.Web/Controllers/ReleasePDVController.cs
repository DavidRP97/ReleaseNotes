using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.PDV;

namespace ReleaseNotes.Web.Controllers
{
    public class ReleasePDVController : Controller
    {
        private readonly IReleasePDVService _releasePDVService;
        public ReleasePDVController(IReleasePDVService releasePDVService)
        {
            _releasePDVService = releasePDVService;
        }
        public async Task<ActionResult> Index()
        {
            var releases = await _releasePDVService.FindAllReleases();
            return View(releases);
        }
        public async Task<ActionResult> Modules(long id)
        {
            var releases = await _releasePDVService.FindAllReleases();
            return View(releases.Where(c => c.ReleaseId == id));
        }
        [Authorize]
        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            string token = string.Empty;
            var model = await _releasePDVService.DeleteReleaseById(id, token);
            if (model != null) return View(model);
            return NotFound();
        }
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ReleasePDVViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _releasePDVService.CreateRelease(model, token);
                if (response != null) return RedirectToAction(nameof(Index));
            }
            return View(model);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> IndexControlPainel()
        {
            var releases = await _releasePDVService.FindAllReleases();
            return View(releases);
        }     
        

    }
}
