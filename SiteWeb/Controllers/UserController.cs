using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;
using SiteWeb.Models;
using System.Security.Claims;

namespace SiteWeb.Controllers
{
    public class UserController : Controller
    {
        private UserService userService = new UserService();
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            ViewData["CurrentUsername"] = claimUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            UserViewModel viewModel = new UserViewModel()
            {
                newUser = new UserAuthVM(),
                ListeUser = userService.getAllUsers()

            };
            return View(viewModel);
        }
       

        [HttpPost]
        public async Task<ActionResult> ListeUserADD(UserViewModel user)
        {

            if (userService.ajouterUser(user.newUser))
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
                ListeUser = userService.getAllUsers()

            };

            return View("Index", viewModel);
        }


        public ActionResult SupprimerUser(UserViewModel user)
        {
            userService.deleteUser(user.newUser);
            UserViewModel viewModel = new UserViewModel()
            {
                newUser = new UserAuthVM(),
                ListeUser = userService.getAllUsers()

            };
            return View("Index", viewModel);

        }

        [HttpPost]
        public async Task<ActionResult> ModifUser(UserViewModel user)
        {
            if (userService.updateUser(user.newUser))
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
                ListeUser = userService.getAllUsers()

            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult ModifierUser(int UserId)
        {
                UserAuthVM user = userService.getUser(UserId);
                UserViewModel viewModel = new UserViewModel()
                {
                    newUser = user,
                    ListeUser = userService.getAllUsers()
                };

                return View("ModifierUser", viewModel);
            

        }
    }
}
