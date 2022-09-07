using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace Fleet.Infra;

public class FleetContextFactory : IDesignTimeDbContextFactory<FleetContext>
{
    public FleetContext CreateDbContext(string[] args)
    {
        var path = Path.Combine(
            Directory.GetCurrentDirectory(),
            @"..\..\TrainTrain.Web"
        );
        Console.WriteLine(path);

        var configuration = new ConfigurationBuilder()
            .SetBasePath(
                path)
            .AddJsonFile("appsettings.json")
            .Build();

        var connectionString = configuration.GetConnectionString("Trucs");
        var optionsBuilder = new DbContextOptionsBuilder<FleetContext>();
        optionsBuilder.UseSqlServer(connectionString);

        return new FleetContext(optionsBuilder.Options);
    }
}