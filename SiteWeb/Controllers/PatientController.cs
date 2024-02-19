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
            PatientViewModel viewModel = new PatientViewModel()
            {
                NewPatient = new PatientVM(),
                Patients = patientService.getAllPatients()

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
        [HttpPost]
        public async Task<ActionResult> ModifPatient(PatientViewModel patient)
        {
            if (patientService.updatePatient(patient.NewPatient))
            {
                ViewData["ValidateMessage"] = "succèsMaj";
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
            return View("Index", viewModel);
        }

        [HttpPost]
        public IActionResult ModifierPatient(int patientId)
        {
            PatientVM patient = patientService.getPatient(patientId);
            PatientViewModel viewModel = new PatientViewModel()
            {
                NewPatient = patient,
                Patients = patientService.getAllPatients()

            };
            
            return View("_ModifierPatient", viewModel);
        }

        public  ActionResult SupprimerPatient(PatientViewModel patient)
        {
            patientService.deletePatient(patient.NewPatient);
            PatientViewModel viewModel = new PatientViewModel()
            {
                NewPatient = new PatientVM(),
                Patients = patientService.getAllPatients()

            };
            return View("Index", viewModel);

        }

    }
}

