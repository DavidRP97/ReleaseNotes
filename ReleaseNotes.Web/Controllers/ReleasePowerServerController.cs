using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;

namespace ReleaseNotes.Web.Controllers
{
    public class ReleasePowerServerController : Controller
    {
        private readonly IReleasePowerServerService _realesePowerServerService;
        public ReleasePowerServerController(IReleasePowerServerService realesePowerServerService)
        {
            _realesePowerServerService = realesePowerServerService;
        }
        public async Task<ActionResult> Index()
        {
            var releases = await _realesePowerServerService.FindAllReleases();
            return View(releases);
        }
        public async Task<ActionResult> Modules(long id)
        {
            var releases = await _realesePowerServerService.FindAllReleases();
            return View(releases.Where(c => c.ReleaseId == id));
        }
    }
}
