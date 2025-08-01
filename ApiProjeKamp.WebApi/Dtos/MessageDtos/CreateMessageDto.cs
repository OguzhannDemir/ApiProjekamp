namespace ApiProjeKamp.WebApi.Dtos.MessageDtos
{
    public class CreateMessageDto
    {
    
        public string NameSurName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SendDate { get; set; }
        public string IsRead { get; set; }
    }
}
