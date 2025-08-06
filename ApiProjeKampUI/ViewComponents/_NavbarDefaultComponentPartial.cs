using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampUI.ViewComponents
{
    public class _NavbarDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
