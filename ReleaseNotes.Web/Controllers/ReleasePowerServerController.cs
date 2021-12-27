using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Service.PowerServer.Models;
using System.Text.Json;
using X.PagedList;

namespace ReleaseNotes.Web.Controllers
{
    public class ReleasePowerServerController : Controller
    {
        private readonly IReleasePowerServerService _realesePowerServerService;
        public ReleasePowerServerController(IReleasePowerServerService realesePowerServerService)
        {
            _realesePowerServerService = realesePowerServerService;
        }
        public async Task<ActionResult> Modules(long id)
        {
            var releases = await _realesePowerServerService.FindAllReleases();
            return View(releases.Where(c => c.ReleaseId == id));
        }
        public async Task<ActionResult> Index()
        {
            var releases = await _realesePowerServerService.FindAllReleases();
            return View(releases);
        }

        [Authorize]
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            var model = await _realesePowerServerService.DeleteReleaseById(id, token);

            if (model == true) return RedirectToAction(nameof(IndexControlPainel));
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(ReleasePowerServerViewModel model)
        {

            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _realesePowerServerService.CreateRelease(model, token);
                TempData["ID"] = JsonSerializer.Serialize(response.ReleaseId);

                return RedirectToAction(nameof(CreateModules));
            }
            return View(model);
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> CreateModules(ModulePowerServerViewModel model)
        {

            if (ModelState.IsValid)
            {


                var token = await HttpContext.GetTokenAsync("access_token");

                var response = await _realesePowerServerService.CreateModule(model, token);

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
            var obj = await _realesePowerServerService.FindReleaseById(id.Value, token);
            if (obj == null)
            {
                return NotFound();
            }

            return View(obj);

        }

        [Authorize]
        [HttpGet]
        public async Task<ActionResult> IndexControlPainel(int? pagina)
        {
            const int PageItens = 10;

            int NumeroPagina = (pagina ?? 1);

            var releases = await _realesePowerServerService.FindAllReleases();

            return View(releases.ToPagedList(NumeroPagina, PageItens));
        }
        public async Task<IActionResult> Update(int id)
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var model = await _realesePowerServerService.FindReleaseById(id, token);
            if (model != null) return View(model);
            return NotFound();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Update(ReleasePowerServerViewModel model)
        {
            if (ModelState.IsValid)
            {
                var token = await HttpContext.GetTokenAsync("access_token");
                var response = await _realesePowerServerService.UpdateRelease(model, token);
                if (response != null) return RedirectToAction(
                     nameof(IndexControlPainel));
            }
            return View(model);
        }
    }
}
