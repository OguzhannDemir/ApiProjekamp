using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampUI.ViewComponents
{
    public class _HeadDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();

        }
    }
}
