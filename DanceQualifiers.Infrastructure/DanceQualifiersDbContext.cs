using DanceQualifiers.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class DanceQualifiersDbContext : IdentityDbContext<AppUser>
{
    public DanceQualifiersDbContext(DbContextOptions<DanceQualifiersDbContext> options)
        : base(options)
    {
    }
}