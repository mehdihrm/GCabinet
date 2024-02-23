using BLL;
using DAL.Entity;
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

            RdvViewModel viewModel = new RdvViewModel()
            {
                newrd = new RdvVM(),
                Listerdv = Rdvservice.getAllRDV(),
                Patients = PatientService.getAllPatients()

            };
            return View(viewModel);
        }

        private RdvService Rdvservice = new RdvService();
        private PatientService PatientService = new PatientService();

        [HttpPost]
        public async Task<ActionResult> ListeRdvADD(RdvViewModel rdv)
        {

            if (Rdvservice.addRdv(rdv.newrd))
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
                Listerdv = Rdvservice.getAllRDV(),
                Patients = PatientService.getAllPatients()

            };

            return View("Index", viewModel);
        }


        public ActionResult SupprimerRdv(RdvViewModel rd)
        {
            Rdvservice.deleteRDV(rd.newrd);
            RdvViewModel viewModel = new RdvViewModel()
            {
                newrd = new RdvVM(),
                Listerdv = Rdvservice.getAllRDV(),
                Patients = PatientService.getAllPatients()



            };
            return View("Index", viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> ModifRdv(RdvViewModel rdv)
        {
            if (Rdvservice.updateRDV(rdv.newrd))
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
                Listerdv = Rdvservice.getAllRDV(),
                Patients = PatientService.getAllPatients()
            };
            string message = $"Id: {rdv.newrd.Id}, PatientId : {rdv.newrd.PatientId}, date : {rdv.newrd.DateRDV}";
            ViewBag.Message = message;
            return View("Index", viewModel);
        }
        [HttpPost]
        public IActionResult ModifierRdv(int RdvId)
        {
                RdvVM rd = Rdvservice.getrdv(RdvId);
                RdvViewModel viewModel = new RdvViewModel()
                {
                    newrd = rd,
                    Listerdv = Rdvservice.getAllRDV(),
                    Patients = PatientService.getAllPatients()

                };

                return View("_ModifierRdv", viewModel);
           
        }


    }
}
