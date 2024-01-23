using BLL;
using DAL.Entity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Models;
using SiteWeb.Models;
using System.Security.Claims;

namespace SiteWeb.Controllers
{
    public class PatientController : Controller
    {
        private PatientService patientService = new PatientService();
        public ActionResult Index()
        {
            ClaimsPrincipal claimUser = HttpContext.User;
            ViewData["CurrentUsername"] = claimUser.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            List<PatientVM> listePatients = patientService.getAllPatients();

            PatientViewModel viewModel = new PatientViewModel()
            {
                NewPatient = new PatientVM(),
                Patients = listePatients
            
            };
            return View(viewModel);
        }

        [HttpPost]
        public async Task<ActionResult> AddPatient(PatientViewModel patient)
        {

            if (patientService.addPatient(patient.NewPatient))
            {
                ViewData["ValidateMessage"] = "succès";
            }
            else
            {
                ViewData["ValidateMessage"] = "existant";
            }

            PatientViewModel viewModel = new PatientViewModel()
            {
                NewPatient = new PatientVM(),
                Patients = patientService.getAllPatients()

            };

            return View("Index",viewModel);
        }

    }
}

