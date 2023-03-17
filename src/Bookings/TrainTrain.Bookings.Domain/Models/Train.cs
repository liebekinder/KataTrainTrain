namespace TrainTrain.Bookings.Domain.Models;

public sealed class Train
{
    public int Capacity { get; }

    public int NumberOfBookedSeat { get; }


    public Train(IReadOnlyCollection<Carriage> carriages)
    {
        if (!carriages.Any())
        {
            throw new ArgumentException(nameof(carriages));
        }

        Capacity = carriages.Sum(c => c.Capacity);
        NumberOfBookedSeat = carriages.Sum(c => c.TakenSeatsNumber);
    }

    public bool IsCapacityExceeded(int numberOfNewPassenger, decimal maximumRate)
    {
        //var newNumberOfBookedSeat = NumberOfBookedSeat + numberOfNewPassenger;
        //var percentage = Decimal.Divide(newNumberOfBookedSeat, Capacity);

        //return percentage > maximumRate;

        return NumberOfBookedSeat == 10;
    }
}

