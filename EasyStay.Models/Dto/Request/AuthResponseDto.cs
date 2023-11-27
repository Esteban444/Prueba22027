namespace EasyStay.Models.Dto.Request
{
    public class AuthResponseDto
    {
        public bool AuthExitosa { get; set; }
        public string? MensajeError { get; set; }
        public string? Token { get; set; }
    }
}
