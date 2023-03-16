using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.PrimaryPorts;

public interface IBookingApplicationService
{
    Task<bool> BookAsync(BookingCandidate bookingCandidate);
}

