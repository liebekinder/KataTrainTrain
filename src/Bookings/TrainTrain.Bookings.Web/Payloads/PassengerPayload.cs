namespace TrainTrain.Bookings.Web.Payloads;

public class PassengerPayload
{
    public string FirstName { get; set; } = string.Empty;

    public string LastName { get; set; } = string.Empty;

    public DateOnly BirthDate { get; set; }
}