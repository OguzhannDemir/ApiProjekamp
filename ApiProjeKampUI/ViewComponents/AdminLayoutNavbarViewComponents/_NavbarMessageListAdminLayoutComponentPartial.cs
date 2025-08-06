using ApiProjeKampUI.Dtos.ChefDtos;
using ApiProjeKampUI.Dtos.MessageDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampUI.ViewComponents.AdminLayoutNavbarViewComponents
{
    public class _NavbarMessageListAdminLayoutComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _HttpClientFactory;
      


        public _NavbarMessageListAdminLayoutComponentPartial(IHttpClientFactory ıHttpClientFactory)
        {
            _HttpClientFactory = ıHttpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Messages/MessageListByIsReadFalse");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultMessageByIsReadFalseDto>>(responseData);
                return View(values);
            }
            return View();
        }





    }
}
