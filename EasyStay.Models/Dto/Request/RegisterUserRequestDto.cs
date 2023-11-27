namespace EasyStay.Models.Dto.Request
{
    public class RegisterUserRequestDto
    {
        public required string UserName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
    }
}
