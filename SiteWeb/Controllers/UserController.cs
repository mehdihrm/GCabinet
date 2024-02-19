using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;
using SiteWeb.Models;
using System.Security.Claims;

namespace SiteWeb.Controllers
{
    public class UserController : Controller
    {
        private AuthService service = new AuthService();
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            ViewData["CurrentUsername"] = claimUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            UserViewModel viewModel = new UserViewModel()
            {
                newUser = new UserAuthVM(),
                ListeUser = service.getAllUsers()

            };
            return View(viewModel);
        }
       

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
                newUser = new UserAuthVM(),
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
                ListeUser = service.getAllUsers()

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
