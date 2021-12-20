using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Web.Context;
using ReleaseNotes.Web.Models;
using System.Diagnostics;

namespace ReleaseNotes.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IReleasePowerServerService _realesePowerServerService;
        private readonly UserManager<ApplicationUser> _userManager;
        public HomeController(ILogger<HomeController> logger, IReleasePowerServerService realesePowerServerService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            _realesePowerServerService = realesePowerServerService;
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var releases = await _realesePowerServerService.FindAllReleases();
            return View(releases);
        }
        public async Task<IActionResult>Login()
        {
            return RedirectToAction("Login", "Authorize");
        }
        public IActionResult Logout()
        {
            return SignOut("Cookies", "oidc");
        }  
        
        [AllowAnonymous]
        public async Task<IActionResult> GetUserEmail()
        {
            try
            {
                var user = User.Identity.Name;
                var userEmail = await _userManager.FindByNameAsync(user);

                
                ViewBag.EmailData = userEmail.Email;

                return Content(ViewBag.EmailData);
            }
            catch (Exception)
            {

                return null;
            }
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