using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Dtos.AboutDtos;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AboutController : ControllerBase
    {


        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public AboutController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult AboutList()
        {
            var values = _context.Abouts.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateAbout(CreateAboutDto createAboutDto)
        {

            var value = _mapper.Map<About>(createAboutDto);
            _context.Abouts.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteAbout(int id)
        {
            var value = _context.Abouts.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Abouts.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı.");
        }

        [HttpGet("{id}")]
        public IActionResult GetAbout(int id)
        {
            var About = _context.Abouts.Find(id);
            if (About == null)
            {
                return NotFound();
            }
            return Ok(About);
        }

        [HttpPut]
        public IActionResult UpdateAbout(UpdateAboutDto aboutUpdateDto)
        {
            var value = _mapper.Map<About>(aboutUpdateDto);
            _context.Abouts.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı.");
        }



    }
}
