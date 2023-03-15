using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.Web;
using TrainTrain.Bookings.ApplicationServices;
using TrainTrain.Bookings.ApplicationServices.PrimaryPorts;

namespace Fleet.Web;

public class BookingsServiceCollection : ProjectServiceCollection
{
    public override void Register(IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IBookingApplicationService, BookingApplicationService>();
    }
}