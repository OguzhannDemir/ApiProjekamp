using ApiProjeKampUI.Dtos.ServiceDto;
using ApiProjeKampUI.Dtos.TestimonialDtos;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;

namespace ApiProjeKampUI.ViewComponents
{
    public class _TestimonialDefaultComponentPartial : ViewComponent
    {
        private readonly IHttpClientFactory httpClientFactory;
        public _TestimonialDefaultComponentPartial(IHttpClientFactory httpClientFactory)
        {
            this.httpClientFactory = httpClientFactory;
        }

        // ViewComponent çağrıldığında çalışacak asenkron metod.
        public async Task<IViewComponentResult> InvokeAsync()
        {
            // HttpClient nesnesi oluşturuluyor.
            var client = httpClientFactory.CreateClient();

            // API'den veri çekiliyor (Testimonial verileri).
            var responseMessage = await client.GetAsync("https://localhost:7045/api/Testimonials");
            if (responseMessage.IsSuccessStatusCode)
            {
                // Gelen JSON verisi string olarak okunuyor.
                var responseData = await responseMessage.Content.ReadAsStringAsync();
                // JSON verisi, ResultTestimonialDto tipinde bir listeye dönüştürülüyor.
                var values = JsonConvert.DeserializeObject<List<ResultTestimonialDto>>(responseData);
                // View'e bu liste gönderiliyor.
                return View(values);
            }
            return View();
        }







    }
}
