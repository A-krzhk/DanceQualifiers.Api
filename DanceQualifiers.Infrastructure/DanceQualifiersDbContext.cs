using DanceQualifiers.Core.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

public class DanceQualifiersDbContext : IdentityDbContext<AppUser>
{
    public DbSet<Direction> Directions { get; set; }
    public DbSet<TimeSlot> TimeSlots { get; set; }
    public DbSet<UserEnrollment> UserEnrollments { get; set; }

    public DanceQualifiersDbContext(DbContextOptions<DanceQualifiersDbContext> options)
        : base(options)
    {
    }

}