using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Entities.Model.ReleasesPowerPDV;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.Models.PDV;
using System.Text.Json;

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
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

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
                TempData["ID"] = JsonSerializer.Serialize(response.ReleaseId);

                return RedirectToAction(nameof(CreateModules));
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateModules(ModulePDVViewModel model)
        {

            if (ModelState.IsValid)
            {   
                

                var token = await HttpContext.GetTokenAsync("access_token");

                var response = await _releasePDVService.CreateModule(model, token);

                TempData["ReleaseId"] = JsonSerializer.Serialize(response.ReleaseId);

                return RedirectToAction(nameof(CreateModules));
            }
            return View(model);
        }
        public async Task<IActionResult> CreateModules()
        {
            return View();
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        public async Task<ActionResult> Delete(long? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var token = await HttpContext.GetTokenAsync("access_token");
            var obj = await _releasePDVService.FindReleaseById(id.Value, token);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

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
