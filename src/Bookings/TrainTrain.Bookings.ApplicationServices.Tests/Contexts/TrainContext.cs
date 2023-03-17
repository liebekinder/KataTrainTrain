using Moq;
using TrainTrain.Bookings.ApplicationServices.SecondaryPorts;

namespace TrainTrain.Bookings.ApplicationServices.Tests.Contexts;

public sealed class TrainContext
{
    public Mock<ITravelRepository> TravelRepository { get; set; } = new Mock<ITravelRepository>();
}