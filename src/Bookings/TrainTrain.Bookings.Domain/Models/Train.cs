namespace TrainTrain.Bookings.Domain.Models;

public sealed class Train
{
    public int Capacity { get; }

    public int NumberOfBookedSeat { get; }

    public Train(int capacity, int initialNumberOfBookedSeat)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException("train capacity should have at least one seat");
        }

        if (initialNumberOfBookedSeat < 0 || initialNumberOfBookedSeat > capacity)
        {
            throw new ArgumentException("booked seat number invalid");
        }

        Capacity = capacity;
        NumberOfBookedSeat = initialNumberOfBookedSeat;
    }

    public bool IsCapacityExceeded(int numberOfNewPassenger, decimal maximumRate)
    {
        var newNumberOfBookedSeat = NumberOfBookedSeat + numberOfNewPassenger;
        var percentage = Decimal.Divide(newNumberOfBookedSeat, Capacity);

        return percentage > maximumRate;
    }
}

