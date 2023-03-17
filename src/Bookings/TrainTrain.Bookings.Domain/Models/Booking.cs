namespace TrainTrain.Bookings.Domain.Models;

public sealed record Booking(TravelId TravelId, Email Email, IReadOnlyCollection<Passenger> Passengers);