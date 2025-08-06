using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TestimonialsController : ControllerBase
    {


        private readonly ApiContext _context;
        public TestimonialsController(ApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult TestimonialList()
        {
            var values = _context.Testimonials.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateTestimonial(Testimonial Testimonial)
        {
            _context.Testimonials.Add(Testimonial);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteTestimonial(int id)
        {
            var value = _context.Testimonials.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Testimonials.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı.");
        }

        [HttpGet("{id}")]
        public IActionResult GetTestimonial(int id)
        {
            var Testimonial = _context.Testimonials.Find(id);
            if (Testimonial == null)
            {
                return NotFound();
            }
            return Ok(Testimonial);
        }

        [HttpPut]
        public IActionResult UpdateTestimonial(int id, Testimonial Testimonial)
        {
            _context.Testimonials.Update(Testimonial);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı.");
        }



    }
}
