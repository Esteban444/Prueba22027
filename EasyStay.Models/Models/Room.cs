using System;

namespace EasyStay.Models.Models
{
    public class Room: BaseModel
    {
        public Guid HotelId { get; set; }
        public string? TypeRoom { get; set; }
        public string? NumberOfRoom { get; set; }
        public bool Available { get; set; }
        public decimal BasePrice { get; set; }
        public decimal Taxes { get; set; }
        public string? City { get; set; }
        public int? NumberOfPerson { get; set; }
        public DateTime? StartDateRoomAvailability { get; set; }
        public DateTime? EndDateRoomAvailability { get; set; }

        public virtual Hotel? Hotel { get; set; }
        public ICollection<Reservation>? Reservations { get; set; }
    }
}
