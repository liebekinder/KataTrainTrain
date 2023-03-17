namespace TrainTrain.Bookings.Domain.Models;

public sealed class Train
{
    private readonly IReadOnlyCollection<Carriage> _carriages;


    public Train(IReadOnlyCollection<Carriage> carriages)
    {
        if (!carriages.Any())
        {
            throw new ArgumentException(nameof(carriages));
        }
        _carriages = carriages;
    }

    public bool IsCapacityExceeded(int numberOfNewPassenger, decimal maximumRate)
    {
        return _carriages.All(c => c.IsCapacityExceeded(numberOfNewPassenger, maximumRate));
    }
}

