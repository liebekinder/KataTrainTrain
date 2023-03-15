namespace TrainTrain.Bookings.Domain.Models;

public sealed class BookingCandidate
{
    public int TravelId { get; }

    public Email Email { get; }

    public IReadOnlyCollection<Passenger> Passengers { get; }

    public BookingCandidate(int travalId, string email, IReadOnlyCollection<Passenger> passengers)
    {
        TravelId = travalId;
        Email = new Email(email);
        Passengers = passengers;
    }
}

