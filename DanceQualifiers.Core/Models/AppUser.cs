using Microsoft.AspNetCore.Identity;
    
namespace DanceQualifiers.Core.Models
{
    public class AppUser : IdentityUser
    {
        public string TelegramName { get; set;}
        public string Name { get; set;}
        public string Surname { get; set; }

    }
}
