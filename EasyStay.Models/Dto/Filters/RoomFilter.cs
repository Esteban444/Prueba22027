using System;

namespace EasyStay.Models.Dto.Filters
{
    public class RoomFilter
    {
        public DateTime? StartDateRoomAvailability { get; set; }
        public DateTime? EndDateRoomAvailability { get; set; }
        public string? City { get; set; }
        public int? NumberOfPerson { get; set; }
    }
}
