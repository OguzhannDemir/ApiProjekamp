using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampUI.ViewComponents.AdminViewComponents
{
    public class _HeadAdminLayoutComponentPartial:ViewComponent
    {

        public IViewComponentResult Invoke()
        {
            return View();
        }


    }
}
