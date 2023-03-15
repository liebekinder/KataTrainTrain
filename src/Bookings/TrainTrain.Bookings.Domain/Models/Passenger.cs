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
}
