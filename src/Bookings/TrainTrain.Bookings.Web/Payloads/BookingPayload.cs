namespace TrainTrain.Bookings.Web.Payloads;

public sealed class BookingPayload
{
    public int TravelId { get; set; }

    public string Email { get; set; } = string.Empty;

    public IReadOnlyCollection<PassengerPayload> Passengers { get; set; } = new List<PassengerPayload>();
}

