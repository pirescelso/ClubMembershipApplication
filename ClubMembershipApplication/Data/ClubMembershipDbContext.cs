using ClubMembershipApplication.Models;
using Microsoft.EntityFrameworkCore;

namespace ClubMembershipApplication;

public class ClubMembershipDbContext : DbContext
{
    // public ClubMembershipDbContext(DbContextOptions<ClubMembershipDbContext> options) : base(options)
    // {
    // }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite($"Data Source={AppDomain.CurrentDomain.BaseDirectory}ClubMembershipDb.db");
        base.OnConfiguring(optionsBuilder);
    }

    public DbSet<User> Users { get; set; }
}
