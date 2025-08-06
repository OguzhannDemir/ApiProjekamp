using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampUI.ViewComponents
{
    public class _FeatureDefaultComponentPartial : ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
