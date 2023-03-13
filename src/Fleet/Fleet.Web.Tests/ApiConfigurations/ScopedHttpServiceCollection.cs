using Fleet.Infra;
using Fleet.Web.Tests.Models.Contexts;
using Lucca.Tests.Api.SpecFlowPlugin;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using TechTalk.SpecFlow;

namespace Fleet.Web.Tests.ApiConfigurations
{
    public class ScopedHttpServiceCollection : IScopedHttpServiceCollection
    {
        private readonly PrincipalContext _principalContext;
        private readonly FeatureContext _featureContext;

        public ScopedHttpServiceCollection(
            PrincipalContext principalContext, FeatureContext featureContext)
        {
            _principalContext = principalContext;
            _featureContext = featureContext;
        }

        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTestAuthentication(_principalContext);

            new FleetServiceCollection().Register(serviceCollection, null);

            serviceCollection.RemoveAll<FleetContext>();

            serviceCollection.AddScoped(_ =>
                new FleetContext(_featureContext.GetDbOptions<FleetContext>()));

        }
    }
}