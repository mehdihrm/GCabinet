using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Models;
using BLL;

namespace SiteWeb.Controllers
{
    public class AuthController : Controller
    {
        public IActionResult Login()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            if(claimUser.Identity.IsAuthenticated)
                return RedirectToAction("Index", "Home");
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(UserAuthVM userLogin)
        {
            AuthService authService = new AuthService();
            if (authService.authentifyUser(userLogin))
            //if(userLogin.Username == "admin" && userLogin.Password=="admin")
            {
                
                List<Claim> claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,userLogin.Username),
                    new Claim("OtherProperties","Admin")
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme);
                
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,
                    IsPersistent = userLogin.KeepLoggedIn
                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(claimsIdentity), properties);


                return RedirectToAction("Index", "Home");
            }
            else
            {
                ViewData["ValidateMessage"] = "user not found";
            }

            
            return View();
        }
    }
}
