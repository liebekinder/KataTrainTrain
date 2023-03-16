using TrainTrain.Bookings.ApplicationServices.Exceptions;
using TrainTrain.Bookings.ApplicationServices.PrimaryPorts;
using TrainTrain.Bookings.ApplicationServices.SecondaryPorts;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices;

public sealed class BookingApplicationService : IBookingApplicationService
{
    private readonly ITravelRepository _travelRepository;

    public BookingApplicationService(ITravelRepository travelRepository)
    {
        _travelRepository = travelRepository;
    }

    public Task BookAsync(BookingCandidate bookingCandidate)
    {
        if (!bookingCandidate.Passengers.Any())
        {
            throw new NoPassengerException();
        }

        return Task.CompletedTask;
    }
}
