using ApiProjeKampUI.Dtos.AboutDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace ApiProjeKampUI.Controllers
{
    public class AboutController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> AboutList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/About");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultAboutDto>>(jsonData);
                return View(values);
            }
            else
            {
                ViewBag.Abouts = "Bir Hata Oluştu";
                return View();
            }
        }


        [HttpGet]
        public IActionResult AboutCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> AboutCreate(AboutCreateDto aboutCreateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(aboutCreateDto);//Metinden Json veriye çevirme
            StringContent stringContent = new StringContent(JsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7045/api/About", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("AboutList");
            }
            return View();
        }


        public async Task<IActionResult> AboutDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7045/api/About?id=" + id);
            return RedirectToAction("AboutList");

        }

        [HttpGet]
        public async Task<IActionResult> AboutUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/About" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<AboutGetByIdDto>(jsonData);
            return View(value);
        }

        [HttpPost]
        public async Task<IActionResult> AboutUpdate(AboutUpdateDto aboutUpdateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(aboutUpdateDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7045/api/About", stringContent);
            return RedirectToAction("AboutList");
        }
    }
}
