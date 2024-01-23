using Microsoft.AspNetCore.Mvc;

namespace SiteWeb.Controllers
{
    public class RDVController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
