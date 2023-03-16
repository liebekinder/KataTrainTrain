namespace TrainTrain.Bookings.Domain.Models;

public class Passenger
{
    public string FirstName { get; }

    public string LastName { get; }

    public DateOnly BirthDate { get; }

    public Passenger(string firstName, string lastName, DateOnly birthDate)
    {
        FirstName = firstName;
        LastName = lastName;
        BirthDate = birthDate;
    }

    public override bool Equals(object? obj)
    {
        if (obj == null) return false;

        var passenger = obj as Passenger;
        if (passenger == null) return false;

        return passenger.LastName == LastName
            && passenger.BirthDate == BirthDate
            && passenger.FirstName == FirstName;
    }
}
