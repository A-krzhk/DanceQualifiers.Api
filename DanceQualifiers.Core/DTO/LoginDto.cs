using System.ComponentModel.DataAnnotations;

namespace DanceQualifiers.Core.DTO
{
    public class LoginDto
    {
        [Required]
        public string PhoneNumber { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
