namespace TrainTrain.Bookings.Domain.Models;

public sealed class Carriage
{
    public int Capacity { get; }

    public int TakenSeatsNumber { get; }

    public Carriage(int capacity, int takenSeatsNumber)
    {
        if (capacity <= 0)
        {
            throw new ArgumentException();
        }

        if (takenSeatsNumber < 0 || capacity < takenSeatsNumber)
        {
            throw new ArgumentOutOfRangeException();
        }

        Capacity = capacity;
        TakenSeatsNumber = takenSeatsNumber;
    }

    public bool IsCapacityExceeded(int numberOfNewPassenger, decimal maximumRate)
    {
        //var newNumberOfBookedSeat = NumberOfBookedSeat + numberOfNewPassenger;
        //var percentage = Decimal.Divide(newNumberOfBookedSeat, Capacity);

        //return percentage > maximumRate;

        return TakenSeatsNumber >= 7;
    }
}