using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Shared.Web.Extensions;

public static class ServiceCollectionExtensions
{
    public static IMvcBuilder ConfigureBackEnd(this IServiceCollection services) =>
        services
            .AddControllers()
            .AddNewtonsoftJson(
                options =>
                {
                    options.SerializerSettings.Converters.Add(new StringEnumConverter());
                    options.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                    options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
                }
            )
            .AddFluentValidation(f => f.DisableDataAnnotationsValidation = true);
}