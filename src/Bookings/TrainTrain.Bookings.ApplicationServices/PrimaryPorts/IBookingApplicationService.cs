using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.PrimaryPorts;

public interface IBookingApplicationService
{
    Task BookAsync(BookingCandidate bookingCandidate);
}

