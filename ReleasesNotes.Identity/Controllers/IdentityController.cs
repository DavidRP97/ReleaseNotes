using IdentityServer4.Services;
using IdentityServer4.Stores;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReleaseNote.Identity.JWT;
using ReleaseNotes.Identity.Context;

namespace ReleaseNotes.Identity.Controllers
{
    public class IdentityController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        private readonly IIdentityServerInteractionService _interaction;
        private readonly IClientStore _clientStore;
        private readonly IAuthenticationSchemeProvider _schemeProvider;
        private readonly IEventService _events;

        private readonly ITokenGenerate _tokenGenerate;

        public IdentityController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, IIdentityServerInteractionService interaction, 
            IClientStore clientStore, IAuthenticationSchemeProvider schemeProvider, IEventService events, ITokenGenerate tokenGenerate)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _interaction = interaction;
            _clientStore = clientStore;
            _schemeProvider = schemeProvider;
            _events = events;
            _tokenGenerate = tokenGenerate;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
