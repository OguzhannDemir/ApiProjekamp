using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampUI.Controllers
{
    public class DefaultController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
