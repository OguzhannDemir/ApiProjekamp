using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampUI.ViewComponents
{
    public class _AboutDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
