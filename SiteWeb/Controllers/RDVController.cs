using Microsoft.AspNetCore.Mvc;
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
    }
}
