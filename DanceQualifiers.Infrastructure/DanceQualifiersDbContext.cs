using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DanceQualifiers.Infrastructure
{
    public class DanceQualifiersDbContext : IdentityDbContext<AppUser>
    {
        public DanceQualifiersDbContext(DbContextOptions<DanceQualifiersDbContext> options) 
            : base(options)
        {
        }
    }
}
