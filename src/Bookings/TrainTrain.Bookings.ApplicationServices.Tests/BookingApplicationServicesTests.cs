using TrainTrain.Bookings.ApplicationServices.PrimaryPorts;

namespace TrainTrain.Bookings.ApplicationServices.Tests;

public class BookingApplicationServicesTests
{
    private readonly IBookingApplicationService _bookingApplicationService;

    public BookingApplicationServicesTests()
    {
        _bookingApplicationService = new BookingApplicationService();
    }

    [Fact]
    public void Test1()
    {

    }
}