using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Web.Models;
using System.Diagnostics;

namespace ReleaseNotes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IRealesePowerServerService _realesePowerServerService;
        public HomeController(ILogger<HomeController> logger, IRealesePowerServerService realesePowerServerService)
        {
            _logger = logger;
            _realesePowerServerService = realesePowerServerService;
        }
        public async Task<IActionResult> Index()
        {
            var releases = await _realesePowerServerService.FindAllReleases();
            return View(releases);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}