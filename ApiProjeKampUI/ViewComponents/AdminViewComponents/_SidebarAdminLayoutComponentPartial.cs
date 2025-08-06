using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKampUI.ViewComponents.AdminViewComponents
{
    public class _SidebarAdminLayoutComponentPartial : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }

    }
}
