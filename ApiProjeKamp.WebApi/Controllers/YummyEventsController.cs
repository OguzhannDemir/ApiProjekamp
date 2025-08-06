using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class YummyEventsController : ControllerBase
    {

        private readonly ApiContext _context;
        public YummyEventsController(ApiContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult YummyEventList()
        {
            var values = _context.YummyEvents.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateYummyEvent(YummyEvent yummyEvent)
        {
            _context.YummyEvents.Add(yummyEvent);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteYummyEvent(int id)
        {
            var value = _context.YummyEvents.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.YummyEvents.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı.");
        }

        [HttpGet("{id}")]
        public IActionResult GetYummyEvent(int id)
        {
            var YummyEvent = _context.YummyEvents.Find(id);
            if (YummyEvent == null)
            {
                return NotFound();
            }
            return Ok(YummyEvent);
        }

        [HttpPut]
        public IActionResult UpdateYummyEvent(int id, YummyEvent yummyEvent)
        {
            _context.YummyEvents.Update(yummyEvent);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı.");
        }



    }
}
