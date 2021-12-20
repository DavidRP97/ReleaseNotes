using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ReleaseNotes.Web.Context;
using ReleaseNotes.Web.JWT;
using ReleaseNotes.Web.Repository;
using ReleaseNotes.Web.ViewModel;
using System.Security.Claims;
using System.Text.Json;

namespace ReleaseNotes.Web.Controllers
{
    public class AuthorizeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly ITokenGenerate _token;
        private readonly IUser _user;

        public AuthorizeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, RoleManager<IdentityRole> roleManager, ITokenGenerate token, IUser user)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
            _token = token;
            _user = user;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByNameAsync(model.Email);
                
                if (user != null)
                {
                    await _signInManager.PasswordSignInAsync(model.Email, model.Password, model.Remember, lockoutOnFailure: false);
                    var token = _token.LoginTokenGenerate(model);

                    HttpContext.Session.SetString("JWTToken", token.Token);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    ModelState.AddModelError("", "Usuario e/ou senha inválidos");
                    return View(model);
                }

            }
            ModelState.AddModelError("", "Usuario e/ou senha inválidos");
            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                ApplicationUser user = new ApplicationUser();
                IdentityResult userCreated;

                if (_user.VerifyRegister() == 0)
                {
                    user.UserName = $"{ model.FirstName}";
                    user.FirstName = model.FirstName;
                    user.LastName = model.LastName;
                    user.Email = model.Email;
                    user.Status = StatusConta.APROVADO;

                    userCreated = await _userManager.CreateAsync(user, model.Password);

                    if (userCreated.Succeeded)
                    {
                        await _userManager.AddToRoleAsync(user, "Admin");
                        await _signInManager.SignInAsync(user, isPersistent: false);

                        var token = _token.RegisterTokenGenerate(model);

                        HttpContext.Session.SetString("JWTToken", token.Token);

                        return RedirectToAction("Index", "Home");
                    }
                }

                user.UserName = $"{ model.FirstName}";
                user.FirstName = model.FirstName;
                user.LastName = model.LastName;
                user.Email = model.Email;
                user.Status = StatusConta.ANALISE;

                userCreated = await _userManager.CreateAsync(user, model.Password);

                if (userCreated.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Usuario");
                    await _signInManager.SignInAsync(user, isPersistent: false);

                    var token = _token.RegisterTokenGenerate(model);

                    HttpContext.Session.SetString("JWTToken", token.Token);

                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (IdentityError erro in userCreated.Errors)
                    {
                        ModelState.AddModelError("", erro.Description);
                    }
                    return View(model);
                }
            }
            return View(model);
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
