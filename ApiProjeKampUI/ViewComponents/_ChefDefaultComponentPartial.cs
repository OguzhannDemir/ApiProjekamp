using ApiProjeKampUI.Dtos.ChefDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampUI.ViewComponents
{
    public class _ChefDefaultComponentPartial:ViewComponent
    {

        private readonly IHttpClientFactory _HttpClientFactory;

        public _ChefDefaultComponentPartial(IHttpClientFactory ıHttpClientFactory)
        {
            _HttpClientFactory = ıHttpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Chefs");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultChefDto>>(responseData);
                return View(values);
            }
            return View();
        }


    }
}
