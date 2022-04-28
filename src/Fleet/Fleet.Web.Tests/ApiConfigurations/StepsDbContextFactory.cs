using Lucca.Tests.Api.SpecFlowPlugin.Configurations;
using Microsoft.EntityFrameworkCore;
using System;

namespace Fleet.Web.Tests.ApiConfigurations;

public class StepsDbContextFactory : IStepsDbContextFactory
{
    private readonly Func<DbContextOptions<DbContext>> _getOptions;

    public StepsDbContextFactory(
        Func<DbContextOptions<DbContext>> getOptions)
    {
        _getOptions = getOptions;
    }


    public DbContext Create() =>
        new(_getOptions());
}