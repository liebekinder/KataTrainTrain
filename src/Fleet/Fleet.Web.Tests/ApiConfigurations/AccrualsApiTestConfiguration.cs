using BoDi;
using Fleet.Web.Tests.Models.Contexts;
using Lucca.Tests.Api.SpecFlowPlugin;
using Lucca.Tests.Api.SpecFlowPlugin.Configurations;
using Lucca.Tests.Api.SpecFlowPlugin.Contexts;
using Microsoft.EntityFrameworkCore;
using TechTalk.SpecFlow;

namespace Fleet.Web.Tests.ApiConfigurations
{
    public class AccrualsApiTestConfiguration : ApiTestConfiguration<LocalStartup>
    {
        protected override IScopedHttpServiceCollection CreateScopedHttpServiceCollection(IObjectContainer objectContainer) =>
            new ScopedHttpServiceCollection(
                objectContainer.Resolve<PrincipalContext>());

        protected override IStepsDbContextFactory CreateStepsDbContextFactory(IObjectContainer objectContainer) =>
            new StepsDbContextFactory(
                () => objectContainer.Resolve<FeatureContext>().GetDbOptions<DbContext>()
                );

        protected override IPrincipalContext CreatePrincipalContext(IObjectContainer objectContainer) =>
            new PrincipalContext();
        protected override DatabaseSeederConfiguration CreateSeederConfiguration(IObjectContainer objectContainer)
        {
            return
                new DatabaseSeederConfiguration();
        }
    }
}