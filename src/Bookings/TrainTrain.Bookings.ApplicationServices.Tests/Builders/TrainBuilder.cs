using Moq;
using TrainTrain.Bookings.ApplicationServices.SecondaryPorts;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.Tests.Builders;

public class TrainBuilder
{
    private TrainBuilder()
    {
    }

    internal static Mock<ITravelRepository> CreateTrain(TravelId travelId, Train? train)
    {
        var trainRepository = new Mock<ITravelRepository>();
        trainRepository
            .Setup(x => x.GetTravelByIdAsync(travelId))
            .ReturnsAsync(train);

        return trainRepository;
    }
}