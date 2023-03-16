using FluentAssertions;
using Moq;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using TrainTrain.Bookings.ApplicationServices.Exceptions;
using TrainTrain.Bookings.ApplicationServices.SecondaryPorts;
using TrainTrain.Bookings.ApplicationServices.Tests.Contexts;
using TrainTrain.Bookings.ApplicationServices.Tests.Models;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.Tests.Steps;

[Binding]
public class BookingSteps
{
    private readonly BookingContext _bookingContext;

    public BookingSteps(BookingContext bookingContext)
    {
        _bookingContext = bookingContext;
    }

    [Given(@"a travel without train")]
    public void GivenATravelWithoutTrain()
    {
        Mock<ITravelRepository> travelRepository = new Mock<ITravelRepository>();
        travelRepository
            .Setup(x => x.GetTravelByIdAsync(1))
            .ReturnsAsync((Train?)null);

        _bookingContext.TravelRepository = travelRepository;
    }

    [Given(@"a train with a capacity of (.*) and (.*) seats already booked")]
    public void GivenATrainWithACapacityOfAndSeatsAlreadyBooked(int capacity, int numberOfSeatBooked)
    {
        Mock<ITravelRepository> travelRepository = new Mock<ITravelRepository>();
        travelRepository
            .Setup(x => x.GetTravelByIdAsync(1))
            .ReturnsAsync(new Train(capacity, numberOfSeatBooked));

        _bookingContext.TravelRepository = travelRepository;
    }

    [When(@"I book without passenger")]
    public async Task WhenIBookWithoutPassenger()
    {
        ITravelRepository _travelRepository = Mock.Of<ITravelRepository>();
        IBookingRepository _bookingRepository = Mock.Of<IBookingRepository>();

        var bookingCandidate = new BookingCandidate(1, "emaikl@email", new List<Passenger>());

        var bookingAppService = new BookingApplicationService(
            _travelRepository,
            _bookingRepository);

        try
        {
            await bookingAppService.BookAsync(bookingCandidate);
        }
        catch (NoPassengerException ex)
        {
            _bookingContext.ActualException = ex;
        }
    }

    [When(@"I book a travel for these passengers")]
    public async Task WhenIBookATravelForThesePassengers(Table table)
    {
        var passengerTable = table.CreateSet<PassengerTable>();
        if (passengerTable == null)
        {
            throw new ArgumentException();
        }

        var passengers = passengerTable
            .Select(x => new Passenger(x.FirstName, x.LastName, x.BirthDate))
            .ToList().AsReadOnly();

        var bookingCandidate = new BookingCandidate(1, "email@email", passengers);

        var bookingAppService = new BookingApplicationService(
            _bookingContext.TravelRepository.Object,
            _bookingContext.BookingRepository.Object);
        try
        {
            await bookingAppService.BookAsync(bookingCandidate);
        }
        catch (Exception ex)
        {
            _bookingContext.ActualException = ex;
        }
    }

    [Then("I cannot book because there are no passenger")]
    public void ThenShouldHaveException()
    {
        _bookingContext.ActualException.GetType().Should().Be(typeof(NoPassengerException));
    }

    [Then(@"I cannot book because there is no train")]
    public void ThenICannotBookBecauseThereIsNoTrain()
    {
        _bookingContext.ActualException.GetType().Should().Be(typeof(TrainNotFoundException));
    }

    [Then(@"I cannot book because the train is full")]
    public void ThenICannotBookBecauseTheTrainIsFull()
    {
        _bookingContext.ActualException.GetType().Should().Be(typeof(TrainFullException));
    }

    [Then(@"my booking is ok")]
    public void ThenMyBookingIsOk()
    {
        _bookingContext.BookingRepository.Verify(x => x.Book(It.IsAny<Booking>()), Times.Once);
    }
}

