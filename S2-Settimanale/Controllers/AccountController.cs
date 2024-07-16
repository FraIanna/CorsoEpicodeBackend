using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using S2_Settimanale.Services;
using S2_Settimanale.Services.Models;
using System.Security.Claims;

namespace S2_Settimanale.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;

        public AccountController(IAuthService authService)
        {
            _authService = authService;
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(User user)
        {
            try
            {
                bool success = await _authService.RegisterUserAsync(user);

                if (success)
                {
                    return RedirectToAction("Login");
                }
            }
            catch (Exception ex)
            {
                ModelState.AddModelError(string.Empty, "Si è verificato un errore durante la registrazione.");
            }
            return View(user);
        }


        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
            try
            {
                var u = _authService.Login(user.UserName, user.Password);
                if (u == null) return RedirectToAction("Index", "Home");

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, u.UserName)
                };
                u.Roles.ForEach(r => claims.Add(new Claim(ClaimTypes.Role, r)));
                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity));
            }
            catch (Exception ex) { 
            }
            return RedirectToAction("Index", "Home");
        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }

    }
}
