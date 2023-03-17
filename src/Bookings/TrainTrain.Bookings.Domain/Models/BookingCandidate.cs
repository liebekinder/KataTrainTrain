namespace TrainTrain.Bookings.Domain.Models;

public record TravelId(int Value);
public sealed class BookingCandidate
{
    public TravelId TravelId { get; }

    public Email Email { get; }

    public IReadOnlyCollection<Passenger> Passengers { get; }

    public BookingCandidate(TravelId travelId, Email email, IReadOnlyCollection<Passenger> passengers)
    {
        TravelId = travelId;
        Email = email;
        Passengers = passengers;
    }
}