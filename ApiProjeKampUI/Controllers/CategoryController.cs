using ApiProjeKampUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ApiProjeKampUI.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        public async Task<IActionResult> CategoryList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            else
            {
                ViewBag.categories = "Bir Hata Oluştu";
                return View();
            }
        }


        [HttpGet]
        public IActionResult CategoryCreate()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CategoryCreate(CategoryCreateDto catetegoryCreateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(catetegoryCreateDto);//Metinden Json veriye çevirme
            StringContent stringContent = new StringContent(JsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7045/api/Categories", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("CategoryList");
            }
            return View();
        }


        public async Task<IActionResult> CategoryDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            await client.DeleteAsync("https://localhost:7045/api/Categories?id=" + id);
            return RedirectToAction("CategoryList");

        }

        [HttpGet]
        public async Task<IActionResult> CategoryUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Categories/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var value = JsonConvert.DeserializeObject<CategoryGetByIdDto>(jsonData);
            return View(value);
        }


        [HttpPost]
        public async Task<IActionResult> CategoryUpdate(CategoryUpdateDto categoryUpdateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(categoryUpdateDto);
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7045/api/Categories", stringContent);
            return RedirectToAction("CategoryList");
        }

    }
}