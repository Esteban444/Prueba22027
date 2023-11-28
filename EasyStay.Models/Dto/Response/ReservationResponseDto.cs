using EasyStay.Models.Models;
using System;

namespace EasyStay.Models.Dto.Response
{
    public class ReservationResponseDto
    {
        public Guid Id { get; set; }
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

        public ClientResponseDto? Client { get; set; }
    }
}
