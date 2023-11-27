namespace EasyStay.Models.Dto.Request
{
    public class HotelRequestDto
    {
        public string? Name { get; set; }
        public string? Address { get; set; }
        public string? City { get; set; }
        public string? Department { get; set; }
        public string? Phone { get; set; }
        public string? Email { get; set; }
        public string? Nit { get; set; }
        public bool Available { get; set; }
    }
}
