using Fleet.Web;
using Microsoft.AspNetCore.Builder;
using Shared.Web;
using Shared.Web.Extensions;

var projectServiceCollections = new ProjectServiceCollection[]
{
    new FleetServiceCollection(),
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
foreach (var services in projectServiceCollections)
{
    services.Register(builder.Services, builder.Configuration);
}

builder.Services.ConfigureBackEnd();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();