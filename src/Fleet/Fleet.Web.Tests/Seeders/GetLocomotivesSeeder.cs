using Fleet.Infra;
using Fleet.Infra.DbModels;
using Lucca.Tests.Api.SpecFlowPlugin;
using Lucca.Tests.Api.SpecFlowPlugin.Seeders;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fleet.Web.Tests.Seeders;

public class GetLocomotivesSeeder : IDatabaseSeeder
{
    public async Task SeedAsync(DbContext dbContext)
    {
        await using var transaction = await dbContext.Database.BeginTransactionAsync();

        await dbContext.AddAndSaveAsync(
            new DbLocomotive
            {
                Brand = "Pacific",
                Name = "231 G",
                Model = DbLocomotiveModel.ModelB,
                MaxTractionInTons = 10,
                WeightInTons = 10,
            });

        await dbContext.AddAndSaveAsync(
            new DbLocomotive
            {
                Brand = "Alsthom",
                Name = "CC 6500",
                Model = DbLocomotiveModel.ModelA,
                WeightInTons = 10,
                MaxTractionInTons = 10
            });

        await transaction.CommitAsync();
    }
}
