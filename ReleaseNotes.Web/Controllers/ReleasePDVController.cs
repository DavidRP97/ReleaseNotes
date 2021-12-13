using Microsoft.AspNetCore.Mvc;

namespace ReleaseNotes.Web.Controllers
{
    public class ReleasePDVController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
