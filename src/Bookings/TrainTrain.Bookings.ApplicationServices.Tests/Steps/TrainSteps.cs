using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TrainTrain.Bookings.ApplicationServices.Tests.Builders;
using TrainTrain.Bookings.ApplicationServices.Tests.Contexts;
using TrainTrain.Bookings.ApplicationServices.Tests.Models;
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
        _trainContext.TravelRepository = TrainBuilder.CreateTrain(new TravelId(1), null);
    }

    [Given(@"a train with a capacity of (.*) and (.*) seats already booked")]
    public void GivenATrainWithACapacityOfAndSeatsAlreadyBooked(int capacity, int numberOfSeatBooked)
    {
        _trainContext.TravelRepository = TrainBuilder.CreateTrain(new TravelId(1), new Train(new[] { new Carriage(capacity, numberOfSeatBooked) }));
    }

    [Given(@"a train with these carriages")]
    public void GivenATrainWithTheseCarriages(Table table)
    {
        var carriages =
            table.CreateSet<CarriageTable>()
            .Select(x => new Carriage(x.Capacity, x.TakenSeatsNumber))
            .ToList();

        _trainContext.TravelRepository = TrainBuilder.CreateTrain(new TravelId(1), new Train(carriages));
    }

}