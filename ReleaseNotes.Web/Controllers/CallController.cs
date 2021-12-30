using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Service.Interfaces;
using ReleaseNotes.Web.Utils;
using X.PagedList;

namespace ReleaseNotes.Web.Controllers
{
    public class CallController : Controller
    {
        private readonly ICallService _callService;

        public CallController(ICallService callService)
        {
            _callService = callService;
        }

        public async Task<IActionResult> Index(int? pagina)
        {
            const int TotalPorPagina = 10;

            int NumeroPagina = (pagina ?? 1);

            var token = await HttpContext.GetTokenAsync("access_token");

            var response = await _callService.FindAllCalls(token);

            if (User.IsInRole(Role.Client))
            {
                string Email = User.Identity.IsAuthenticated ? User.Claims.FirstOrDefault(x => x.Type == "email").Value : string.Empty;

                return View(response.OrderByDescending(x => x.IsUrgent).Where(x => x.Email == Email).ToPagedList(NumeroPagina, TotalPorPagina));
            }

            return View(response.OrderByDescending(x => x.IsUrgent).ToPagedList(NumeroPagina, TotalPorPagina));

        }
    }
}
