using System;

namespace EasyStay.Models.Dto.Response
{
    public class ClientResponseDto
    {
        public Guid Id { get; set; }
        public string? FirtsName { get; set; }
        public string? SecondName { get; set; }
        public string? LastName { get; set; }
        public string? SecondLastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Gender { get; set; }
        public string? TypeDocument { get; set; }
        public string? NumberDocument { get; set; }
        public string? Email { get; set; }
        public string? Phone { get; set; }
    }
}
