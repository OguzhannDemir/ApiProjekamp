﻿namespace ApiProjeKamp.WebApi.Entities
{
    public class Message
    {
        public int MessageId { get; set; }
        public string NameSurName { get; set; }
        public string Email { get; set; }
        public string Subject { get; set; }
        public string MessageDetails { get; set; }
        public DateTime SendDate { get; set; }
        public string IsRead { get; set; }


    }
}
