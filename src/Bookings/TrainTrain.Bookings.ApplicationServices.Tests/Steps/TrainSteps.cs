using Moq;
using TechTalk.SpecFlow;
using TrainTrain.Bookings.ApplicationServices.SecondaryPorts;
using TrainTrain.Bookings.ApplicationServices.Tests.Builders;
using TrainTrain.Bookings.ApplicationServices.Tests.Contexts;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.Tests.Steps;

[Binding]
public class TrainSteps
{
    private readonly TrainContext _trainContext;

    public TrainSteps(TrainContext trainContext)
    {
        _trainContext = trainContext;
    }

    [Given(@"a travel without train")]
    public void GivenATravelWithoutTrain()
    {
        var travelRepository = new Mock<ITravelRepository>();
        travelRepository
            .Setup(x => x.GetTravelByIdAsync(1))
            .ReturnsAsync((Train?)null);

        _trainContext.TravelRepository = TrainBuilder.CreateTrain(1, null);
    }

    [Given(@"a train with a capacity of (.*) and (.*) seats already booked")]
    public void GivenATrainWithACapacityOfAndSeatsAlreadyBooked(int capacity, int numberOfSeatBooked)
    {
        var travelRepository = new Mock<ITravelRepository>();
        travelRepository
            .Setup(x => x.GetTravelByIdAsync(1))
            .ReturnsAsync(new Train(capacity, numberOfSeatBooked));

        _trainContext.TravelRepository = TrainBuilder.CreateTrain(1, new Train(capacity, numberOfSeatBooked));
    }
}

