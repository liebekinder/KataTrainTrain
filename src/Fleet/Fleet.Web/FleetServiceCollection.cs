using Fleet.Infra;
using Fleet.Infra.Repositories;
using Fleet.Web.Payloads;
using Fleet.Web.Validators;
using FluentValidation;
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

        services.AddScoped<IValidator<LocomotivePayload>, LocomotivePayloadValidator>();
    }
}