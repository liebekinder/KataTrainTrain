using BoDi;
using Fleet.Infra;
using Fleet.Web.Tests.Models.Contexts;
using Fleet.Web.Tests.Seeders;
using Lucca.Tests.Api.SpecFlowPlugin;
using Lucca.Tests.Api.SpecFlowPlugin.Configurations;
using Lucca.Tests.Api.SpecFlowPlugin.Contexts;
using TechTalk.SpecFlow;

namespace Fleet.Web.Tests.ApiConfigurations
{
    public class AccrualsApiTestConfiguration : ApiTestConfiguration<LocalStartup>
    {
        protected override IScopedHttpServiceCollection CreateScopedHttpServiceCollection(IObjectContainer objectContainer) =>
            new ScopedHttpServiceCollection(
                objectContainer.Resolve<PrincipalContext>(),
                objectContainer.Resolve<FeatureContext>());

        protected override IStepsDbContextFactory CreateStepsDbContextFactory(IObjectContainer objectContainer) =>
            new StepsDbContextFactory(
                () => objectContainer.Resolve<FeatureContext>().GetDbOptions<FleetContext>()
                );

        protected override IPrincipalContext CreatePrincipalContext(IObjectContainer objectContainer) =>
            new PrincipalContext();
        protected override DatabaseSeederConfiguration CreateSeederConfiguration(IObjectContainer objectContainer)
        {
            return
                new DatabaseSeederConfiguration()
                    .Associate("GetLoco").With(new GetLocomotivesSeeder())
                    .Associate("DelLoco").With(new DeleteLocomotiveSeeder())
                    .Associate("CreateLoco").With(new CreateLocomotivesSeeder());
        }
    }
}