using Moq;
using TrainTrain.Bookings.ApplicationServices.SecondaryPorts;

namespace TrainTrain.Bookings.ApplicationServices.Tests.Contexts;

public sealed class BookingContext
{
    public Mock<IBookingRepository> BookingRepository { get; set; } = new Mock<IBookingRepository>();

    public Exception? ActualException { get; set; }
}