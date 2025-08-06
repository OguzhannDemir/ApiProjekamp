using ApiProjeKampUI.Dtos.EventDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampUI.ViewComponents
{
    public class _EventDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory _HttpClientFactory;

        public _EventDefaultComponentPartial(IHttpClientFactory ıHttpClientFactory)
        {
            _HttpClientFactory = ıHttpClientFactory;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var client = _HttpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/YummyEvents");
            if (responseMessage.IsSuccessStatusCode)
            {
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultEventDto>>(responseData);
                return View(values);
            }
            return View();
        }


    }
}
