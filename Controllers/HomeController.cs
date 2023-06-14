using Microsoft.AspNetCore.Mvc;

namespace VoitureExpress.Controllers
{

    public class HomeController : Controller
    {
        public IActionResult Accueil()
        {
            return View();
        }
    }
}
