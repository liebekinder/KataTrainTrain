namespace TrainTrain.Bookings.Domain.Models;

public sealed record Booking(int TravelId, Email Email, IReadOnlyCollection<Passenger> Passengers);

