using TrainTrain.Bookings.ApplicationServices.Exceptions;
using TrainTrain.Bookings.ApplicationServices.PrimaryPorts;
using TrainTrain.Bookings.ApplicationServices.SecondaryPorts;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices;

public sealed class BookingApplicationService : IBookingApplicationService
{
    private readonly ITravelRepository _travelRepository;
    private readonly IBookingRepository _bookingRepository;

    public BookingApplicationService(ITravelRepository travelRepository, IBookingRepository bookingRepository)
    {
        _travelRepository = travelRepository;
        _bookingRepository = bookingRepository;
    }

    public async Task BookAsync(BookingCandidate bookingCandidate)
    {
        if (!bookingCandidate.Passengers.Any())
        {
            throw new NoPassengerException();
        }

        var train = await _travelRepository.GetTravelByIdAsync(bookingCandidate.TravelId);
        if (train == null)
        {
            throw new TrainNotFoundException();
        }

        if (train.IsCapacityExceeded(bookingCandidate.Passengers.Count(), 0.7m))
        {
            throw new TrainFullException();
        }

        throw new NotImplementedException();
    }
}
