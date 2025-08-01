namespace ApiProjeKamp.WebApi.Entities
{
    public class Reservation
    {

        public int ReservationId { get; set; }

        public string NameSurName { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public DateTime ReservationDate { get; set; }

        public string ReservationTime { get; set; }

        public int CountofPeople { get; set; }

        public string Message { get; set; }

        public string ResevationStatus { get; set; }
    }
}
