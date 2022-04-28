using Fleet.Web.Tests.ApiConfigurations;
using Lucca.Tests.Api.SpecFlowPlugin.Configurations;
using TechTalk.SpecFlow;

namespace Fleet.Web.Tests.Steps;

[Binding]
public class StartupSteps
{
    [BeforeTestRun]
    public static void Initialize()
    {
        ApiTestConfiguration.Register<AccrualsApiTestConfiguration>();
    }
}