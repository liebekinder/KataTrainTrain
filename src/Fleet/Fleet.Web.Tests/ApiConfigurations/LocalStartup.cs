using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization; 


namespace Fleet.Web.Tests.ApiConfigurations;

public class LocalStartup
{
    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
        }

        app.UseHttpsRedirection();

        app.UseAuthentication();
        app.UseRouting();

        app.UseAuthorization();

        app.UseEndpoints(endpoints => { endpoints.MapControllers(); });
    }

    // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.

    public void ConfigureServices(IServiceCollection services)
    {
        services
            .AddControllers()
            .AddFluentValidation(f => f.DisableDataAnnotationsValidation = true);
    }
}