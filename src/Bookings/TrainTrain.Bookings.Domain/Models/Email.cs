namespace TrainTrain.Bookings.Domain.Models;

public class Email
{
    private string _email;

    public Email(string email)
    {
        if (!email.Contains('@'))
        {
            throw new FormatException("pas bon");
        }

        _email = email;
    }
}