using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Dtos.CategoryDtos;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {

        private readonly ApiContext _context;
        private readonly IMapper _mapper;
        public CategoriesController(ApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }


        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);
        }

        [HttpPost]
        public IActionResult CreateCategory(CreateCategoryDto createCategoryDto)
        {

            var value = _mapper.Map<Category>(createCategoryDto);
            _context.Categories.Add(value);
            _context.SaveChanges();
            return Ok("Ekleme İşlemi Başarılı.");
        }

        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var value = _context.Categories.Find(id);
            if (value == null)
            {
                return NotFound();
            }
            _context.Categories.Remove(value);
            _context.SaveChanges();
            return Ok("Silme İşlemi Başarılı.");
        }

        [HttpGet("{id}")]
        public IActionResult GetCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            return Ok(category);
        }

        [HttpPut]
        public IActionResult UpdateCategory(CategoryUpdateDto categoryUpdateDto)
        {
            var value = _mapper.Map<Category>(categoryUpdateDto);
            _context.Categories.Update(value);
            _context.SaveChanges();
            return Ok("Güncelleme İşlemi Başarılı.");
        }

    }
}
