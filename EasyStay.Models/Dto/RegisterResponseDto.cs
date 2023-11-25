namespace EasyStay.Models.Dto
{
    public class RegisterResponseDto
    {
        public bool IsSuccess { get; set; }
        public IEnumerable<string>? Errors { get; set; }
    }
}
