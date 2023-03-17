namespace TrainTrain.Bookings.Domain.Models;

public sealed class Train
{
    public int Capacity { get; }

    public int NumberOfBookedSeat { get; }

    private readonly IReadOnlyCollection<Carriage> _carriages;


    public Train(IReadOnlyCollection<Carriage> carriages)
    {
        if (!carriages.Any())
        {
            throw new ArgumentException(nameof(carriages));
        }

        Capacity = carriages.Sum(c => c.Capacity);
        NumberOfBookedSeat = carriages.Sum(c => c.TakenSeatsNumber);
        _carriages = carriages;
    }

    public bool IsCapacityExceeded(int numberOfNewPassenger, decimal maximumRate)
    {
        return _carriages.Any(c => c.IsCapacityExceeded(numberOfNewPassenger, maximumRate));
    }
}

