using TrainTrain.Bookings.Domain.Models;
using TrainTrain.Bookings.Web.Payloads;

namespace TrainTrain.Bookings.Web.Mappers;

public sealed class BookingMapper
{
    public static BookingCandidate ToCandidate(BookingPayload payload)
    {
        return new BookingCandidate(
            payload.TravelId,
            payload.Email,
            payload.Passengers.Select(pas =>
                new Passenger(
                    pas.FirstName,
                    pas.LastName,
                    pas.BirthDate)).ToList());
    }
}

