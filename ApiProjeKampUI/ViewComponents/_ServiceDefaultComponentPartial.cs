using ApiProjeKampUI.Dtos.ServiceDto;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace ApiProjeKampUI.ViewComponents
{
    public class _ServiceDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _ServiceDefaultComponentPartial(IHttpClientFactory ıHttpClientFactory)
        {
            _HttpClientFactory = ıHttpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Services");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultServiceDto>>(responseData);
                return View(values);
            }
            return View();
        }






    }
}
