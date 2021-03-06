using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Web.Models;
using System.Diagnostics;

namespace ReleaseNotes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReleasePowerServerService _realesePowerServerService;
        public HomeController(ILogger<HomeController> logger, IReleasePowerServerService realesePowerServerService)
        {
            _logger = logger;
            _realesePowerServerService = realesePowerServerService;
        }
        public async Task<IActionResult> Index()
        {
            var token = await HttpContext.GetTokenAsync("access_token");
            var releases = await _realesePowerServerService.FindAllReleases();
            return View(releases);
        }
        [Authorize]
        public async Task<IActionResult>Login()
        {
            var accessToken = await HttpContext.GetTokenAsync("access_token");
            
            return RedirectToAction(nameof(Index));
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
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