using ApiProjeKampUI.Dtos.FeatureDtos;
using ApiProjeKampUI.Dtos.FeatureDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampUI.Controllers
{
    public class FeatureController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public FeatureController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> FeatureList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Features");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureDto>>(jsonData);
                return View(values);
            }
            else
            {
                ViewBag.categories = "Bir Hata Oluştu";
                return View();
            }
        }


        [HttpGet]
        public IActionResult FeatureCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> FeatureCreate(FeatureCreateDto FeatureCreateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(FeatureCreateDto);//Metinden Json veriye çevirme
            StringContent stringContent = new StringContent(JsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7045/api/Features", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("FeatureList");
            }
            return View();
        }


        public async Task<IActionResult> FeatureDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7045/api/Features?id=" + id);
            return RedirectToAction("FeatureList");

        }

        [HttpGet]
        public async Task<IActionResult> FeatureUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Features/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<FeatureGetByIdDto>(jsonData);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> FeatureUpdate(FeatureUpdateDto FeatureUpdateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(FeatureUpdateDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7045/api/Features", stringContent);
            return RedirectToAction("FeatureList");
        }

    }
}
