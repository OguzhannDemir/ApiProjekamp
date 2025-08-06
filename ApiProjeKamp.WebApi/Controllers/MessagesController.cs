using ApiProjeKamp.WebApi.Context;
using ApiProjeKamp.WebApi.Dtos.MessageDtos;
using ApiProjeKamp.WebApi.Entities;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjeKamp.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessagesController : ControllerBase
    {

        private readonly IMapper _mapper;
        private readonly ApiContext _context;

        public MessagesController(IMapper mapper, ApiContext context)
        {
            _mapper = mapper;
            _context = context;
        }


        [HttpGet]
        public IActionResult MessageList()
        {
            var values = _context.Messages.ToList();
            return Ok(_mapper.Map<List<ResaultMessageDto>>(values));
        }

        [HttpPost]
        public IActionResult CreateMessage(CreateMessageDto createMessageDto)
        {
            var value = _mapper.Map<Message>(createMessageDto);
            _context.Messages.Add(value);
            _context.SaveChanges();
            return Ok("Mesaj Başarıyla Gönderildi.");
        }

        [HttpDelete]
        public IActionResult DeleteMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound("Mesaj Bulunamadı.");
            }
            _context.Messages.Remove(value);
            _context.SaveChanges();
            return Ok("Mesaj Başarıyla Silindi.");
        }

        [HttpGet("GetByIdMessage")]
        public IActionResult GEtByIdMessage(int id)
        {
            var value = _context.Messages.Find(id);
            if (value == null)
            {
                return NotFound("Mesaj Bulunamadı.");
            }
            _context.Messages.Find(id);
            _context.SaveChanges();
            return Ok(_mapper.Map<GetByIdMessageDto>(value));
        }

        [HttpPut]// gönderilen mesaj güncellenmez bu çalışmıcak
        public IActionResult UpdateMessage(UpdateMessageDto updateMessageDto)
        {
            var value = _mapper.Map<Message>(updateMessageDto);
            _context.Messages.Update(value);
            _context.SaveChanges();
            return Ok("Mesaj Başarıyla Güncellendi.");
        }

        [HttpGet("MessageListByIsReadFalse")]
        public IActionResult MessageListByIsReadFalse()
        {
            var values = _context.Messages.Where(x => x.IsRead == "False").ToList();
            if (values.Count == 0)
            {
                return NotFound("Okunmamış Mesaj Bulunamadı.");
            }
            return Ok(_mapper.Map<List<ResaultMessageDto>>(values));

        }







    }
}
