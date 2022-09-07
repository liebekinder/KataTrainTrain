using Microsoft.EntityFrameworkCore;

namespace Fleet.Infra;

public class FleetContext : DbContext
{
    public FleetContext(DbContextOptions<FleetContext> options)
        : base(options)
    {
    }
}