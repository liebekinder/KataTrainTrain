using TrainTrain.Bookings.ApplicationServices.PrimaryPorts;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices;

public sealed class BookingApplicationService : IBookingApplicationService
{
    public Task BookAsync(BookingCandidate bookingCandidate)
    {
        throw new NotSupportedException();
    }
}
