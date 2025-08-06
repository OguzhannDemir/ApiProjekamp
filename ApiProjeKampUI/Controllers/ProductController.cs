using ApiProjeKampUI.Dtos.CategoryDtos;
using ApiProjeKampUI.Dtos.ProductDtos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;

namespace ApiProjeKampUI.Controllers
{
    public class ProductController : Controller
    {


        private readonly IHttpClientFactory _httpClientFactory;
        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }


        public async Task<IActionResult> ProductList()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Products/ProductListWithCatgory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);
                return View(values);
            }
            else
            {
                ViewBag.products = "Bir Hata Oluştu";
                return View();
            }
        }

        [HttpGet]
        public async Task<IActionResult> ProductCreate()
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Categories");
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
            List<SelectListItem> values2=(from x in values
                                                select new SelectListItem
                                                {
                                                    Text = x.CategoryName,
                                                    Value = x.CategoryId.ToString()
                                                }).ToList();
            ViewBag.CategoryName = values2;
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> ProductCreate(ProductCreateDto productCreateDto)
        {
            var client = _httpClientFactory.CreateClient();
            var JsonData = JsonConvert.SerializeObject(productCreateDto); // Metinden Json veriye çevirme
            StringContent stringContent = new StringContent(JsonData, System.Text.Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7045/api/Products/CreateProductWithCategory", stringContent);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("ProductList");
            }
            return View();
        }

        public async Task<IActionResult> ProductDelete(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.DeleteAsync("https://localhost:7045/api/Products?id=" + id);
            return RedirectToAction("ProductList");
        }


        [HttpGet]
        public async Task<IActionResult> ProductUpdate(int id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Products/" + id);
            var jsonData = await responseMessage.Content.ReadAsStringAsync();
            var values = JsonConvert.DeserializeObject<ProductGetByIdDto>(jsonData);
            return View(values);
        }

        [HttpPost]
        public async Task<IActionResult> ProductUpdate(ProductGetByIdDto productGetByIdDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(productGetByIdDto);// Metinden Json veriye çevirme
            StringContent stringContent = new StringContent(jsonData, System.Text.Encoding.UTF8, "application/json");
            await client.PutAsync("https://localhost:7045/api/Products", stringContent);
            return RedirectToAction("ProductList");

        }


    }

}
