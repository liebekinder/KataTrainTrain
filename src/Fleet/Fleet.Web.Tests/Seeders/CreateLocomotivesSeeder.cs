using Lucca.Tests.Api.SpecFlowPlugin.Seeders;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Fleet.Web.Tests.Seeders;

public class CreateLocomotivesSeeder : IDatabaseSeeder
{
    public async Task SeedAsync(DbContext dbContext)
    {
        await Task.CompletedTask;
    }
}
