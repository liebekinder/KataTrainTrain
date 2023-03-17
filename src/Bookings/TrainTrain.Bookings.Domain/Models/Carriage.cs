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

        if (takenSeatsNumber <= 0 || takenSeatsNumber > capacity)
        {
            throw new ArgumentOutOfRangeException();
        }

        Capacity = capacity;
        TakenSeatsNumber = takenSeatsNumber;
    }
}

