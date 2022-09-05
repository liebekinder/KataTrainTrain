using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Shared.Web;

var projectServiceCollections = new ProjectServiceCollection[]
{
};

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
foreach (var services in projectServiceCollections)
{
    services.Register(builder.Services, builder.Configuration);
}

builder.Services.AddControllers();

var app = builder.Build();
app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();