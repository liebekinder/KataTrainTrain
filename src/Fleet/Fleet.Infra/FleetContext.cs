using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Fleet.Infra;

public class FleetContext : DbContext
{
    public FleetContext(DbContextOptions<FleetContext> options)
        : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}