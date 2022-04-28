using Fleet.Web.Tests.Models.Contexts;
using Lucca.Tests.Api.SpecFlowPlugin;
using Microsoft.Extensions.DependencyInjection;

namespace Fleet.Web.Tests.ApiConfigurations
{
    public class ScopedHttpServiceCollection : IScopedHttpServiceCollection
    {
        private readonly PrincipalContext _principalContext;

        public ScopedHttpServiceCollection(
            PrincipalContext principalContext)
        {
            _principalContext = principalContext;
        }
        public void Register(IServiceCollection serviceCollection)
        {
            serviceCollection.AddTestAuthentication(_principalContext);
        }
    }
}