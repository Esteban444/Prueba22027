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
    }
}
