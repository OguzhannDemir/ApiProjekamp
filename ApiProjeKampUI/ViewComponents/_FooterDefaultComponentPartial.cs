using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampUI.ViewComponents
{
    public class _FooterDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
