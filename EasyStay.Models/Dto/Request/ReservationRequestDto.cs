using System;

namespace EasyStay.Models.Dto.Request
{
    public class ReservationRequestDto
    {
        public Guid? RoomId { get; set; }
        public Guid? ClientId { get; set; }
        public string? TypeRoom { get; set; }
        public string? RoomNumber { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string? City { get; set; }
        public int NumberOfPersons { get; set; }
        public string? EmergencyContactName { get; set; }
        public string? EmergencyContactPhoneNumber { get; set; }
    }
}
