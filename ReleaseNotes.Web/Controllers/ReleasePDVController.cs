using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;

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
    }
}
