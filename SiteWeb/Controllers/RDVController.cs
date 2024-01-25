using BLL;
using Microsoft.AspNetCore.Mvc;
using Models;
using SiteWeb.Models;
using System.Security.Claims;

namespace SiteWeb.Controllers
{
    public class RDVController : Controller
    {
        public IActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            ViewData["CurrentUsername"] = claimUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            return View();
        }

        private RdvService service = new RdvService();

        [HttpPost]
        public async Task<ActionResult> ListeRdvADD(RdvViewModel user)
        {

            if (service.addRdv(user.newrd))
            {
                ViewData["ValidateMessage"] = "succès";
            }
            else
            {
                ViewData["ValidateMessage"] = "existant";
            }

            RdvViewModel viewModel = new RdvViewModel()
            {
                newrd = new RdvVM(),
                Listerdv = service.getAllRDV()

            };

            return View("Index", viewModel);
        }


        public ActionResult SupprimerRdv(RdvViewModel rd)
        {
            service.deleteRDV(rd.newrd);
            RdvViewModel viewModel = new RdvViewModel()
            {
                newrd = new RdvVM(),
                Listerdv = service.getAllRDV()

            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> ModifRdv(RdvViewModel rd)
        {
            if (service.updateRDV(rd.newrd))
            {
                ViewData["ValidateMessage"] = "succèsMaj";
            }
            else
            {
                ViewData["ValidateMessage"] = "existant";
            }
            RdvViewModel viewModel = new RdvViewModel()
            {
                newrd = new RdvVM(),
                Listerdv = service.getAllRDV()

            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult ModifierRdv(int RdId)
        {
            RdvVM rd = service.getrd(RdId);

            if (rd != null)
            {
                RdvViewModel viewModel = new RdvViewModel()
                {
                    newrd = rd,
                    Listerdv = service.getAllRDV()
                };

                return View("ModifierRdv", viewModel);
            }
            else
            {
                return RedirectToAction("Index");
            }
        }


    }
}
