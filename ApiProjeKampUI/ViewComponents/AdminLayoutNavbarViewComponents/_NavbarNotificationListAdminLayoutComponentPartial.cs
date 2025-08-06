using ApiProjeKampUI.Dtos.MessageDtos;
using ApiProjeKampUI.Dtos.NotificationDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarNotificationListAdminLayoutComponentPartial:ViewComponent
    {
       
        private readonly IHttpClientFactory _HttpClientFactory;



        public _NavbarNotificationListAdminLayoutComponentPartial(IHttpClientFactory ıHttpClientFactory)
        {
            _HttpClientFactory = ıHttpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Notifications");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultNotificationDto>>(responseData);
                return View(values);
            }
            return View();
        }

    }
}
