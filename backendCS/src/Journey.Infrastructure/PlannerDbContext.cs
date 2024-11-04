using Microsoft.EntityFrameworkCore;
using Planner.Infrastructure.Entities;

namespace Planner.Infrastructure;

public class PlannerDbContext : DbContext
{
    public DbSet<Trip> Trips { get; set; }
    public DbSet<Activity> Activities { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=\\\\wsl.localhost\\Debian\\home\\roger\\Documents\\journey");
    }
}
