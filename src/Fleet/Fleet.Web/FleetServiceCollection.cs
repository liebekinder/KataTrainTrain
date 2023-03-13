using Fleet.Infra;
using Fleet.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Web;

namespace Fleet.Web;

public class FleetServiceCollection : ProjectServiceCollection
{
    public override void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<LocomotiveRepository>();

        services.AddDbContext<FleetContext>(options => options.UseSqlServer(
            configuration.GetConnectionString("Fleet")));
    }
}