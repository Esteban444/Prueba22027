using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EasyStay.Models.Dto.Response
{
    public class RoomResponseDto
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
