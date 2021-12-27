using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace ReleaseNotes.Web.Controllers
{
    public class FeedbackController : Controller
    {
        public async Task<IActionResult> Index()
        {
            var token = await HttpContext.GetTokenAsync("access_token");

            ViewBag.Token = token;

            return View();
        }
    }
}
