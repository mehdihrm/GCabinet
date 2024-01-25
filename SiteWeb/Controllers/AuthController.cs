using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Models;
using BLL;
using SiteWeb.Models;

namespace SiteWeb.Controllers
{
    public class AuthController : Controller
    {
        public ActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            ViewData["CurrentUsername"] = claimUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            UserViewModel viewModel = new UserViewModel()
            {
                newUser = new UserAuthVM(),
                ListeUser= service.getAllUsers()

            };
            return View(viewModel);
        }
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
                ViewData["ValidateMessage"] = "Username ou mot de passe incorrect !";
            }

            
            return View();
        }
        private AuthService service= new AuthService();

        [HttpPost]
        public async Task<ActionResult> ListeUserADD(UserViewModel user)
        {

            if (service.ajouterUser(user.newUser))
            {
                ViewData["ValidateMessage"] = "succès";
            }
            else
            {
                ViewData["ValidateMessage"] = "existant";
            }

            UserViewModel viewModel = new UserViewModel()
            {
                newUser  = new UserAuthVM(),
                ListeUser = service.getAllUsers()

            };

            return View("Index", viewModel);
        }


        public ActionResult SupprimerUser(UserViewModel user)
        {
            service.deleteUser(user.newUser);
            UserViewModel viewModel = new UserViewModel()
            {
                newUser = new UserAuthVM(),
                ListeUser = service.getAllUsers()

            };
            return View("Index", viewModel);

        }

        [HttpPost]
        public async Task<ActionResult> ModifUser(UserViewModel user)
        {
            if (service.updateUser(user.newUser))
            {
                ViewData["ValidateMessage"] = "succèsMaj";
            }
            else
            {
                ViewData["ValidateMessage"] = "existant";
            }
            UserViewModel viewModel = new UserViewModel()
            {
                newUser = new UserAuthVM(),
                ListeUser= service.getAllUsers()

            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult ModifierUser(int UserId)
        {
            UserAuthVM user = service.getUser(UserId);

            if (user != null)
            {
                UserViewModel viewModel = new UserViewModel()
                {
                    newUser = user,
                    ListeUser = service.getAllUsers()
                };

                return View("ModifierUser", viewModel);
            }
            else
            {
                // Gérer le cas où l'utilisateur n'est pas trouvé
                return RedirectToAction("Index"); // Rediriger vers la vue par défaut ou une vue d'erreur
            }
        }

    }
}
