using Fleet.Infra;
using Lucca.Tests.Api.SpecFlowPlugin.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fleet.Web.Tests.ApiConfigurations;

public class StepsDbContextFactory : IStepsDbContextFactory
{
    private readonly Func<DbContextOptions<FleetContext>> _getOptions;

    public StepsDbContextFactory(
        Func<DbContextOptions<FleetContext>> getOptions)
    {
        _getOptions = getOptions;
    }


    public DbContext Create() =>
        new FleetContext(_getOptions());
}