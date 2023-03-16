using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.SecondaryPorts;

public interface IBookingRepository
{
    Task Book(Booking booking);
}
