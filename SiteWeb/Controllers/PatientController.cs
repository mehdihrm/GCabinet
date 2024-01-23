using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace SiteWeb.Controllers
{
    public class PatientController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

    }
}

