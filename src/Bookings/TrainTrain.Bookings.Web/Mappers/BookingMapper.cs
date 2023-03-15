using TrainTrain.Bookings.Domain.Models;
using TrainTrain.Bookings.Web.Payloads;

namespace TrainTrain.Bookings.Web.Mappers;

public sealed class BookingMapper
{
    public static BookingCandidate ToCandidate(BookingPayload payload)
    {
        return new BookingCandidate
        {
            TravelId = payload.TravelId,
            Email = payload.Email,
            Passengers = payload.Passengers.Select(pas =>
                new Passenger
                {
                    FirstName = pas.FirstName,
                    LastName = pas.LastName,
                    BirthDate = pas.BirthDate,
                }).ToList()
        };
    }
}

