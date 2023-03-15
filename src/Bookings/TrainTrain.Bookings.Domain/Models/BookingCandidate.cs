namespace TrainTrain.Bookings.Domain.Models;

public sealed class BookingCandidate
{
    public int TravelId { get; set; }

    public string Email { get; set; } = string.Empty;

    public IReadOnlyCollection<Passenger> Passengers { get; set; } = new List<Passenger>();
}

