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
        var travelRepository = new Mock<ITravelRepository>();
        travelRepository
            .Setup(x => x.GetTravelByIdAsync(1))
            .ReturnsAsync((Train?)null);

        _bookingContext.TravelRepository = travelRepository;
    }

    [Given(@"a train with a capacity of (.*) and (.*) seats already booked")]
    public void GivenATrainWithACapacityOfAndSeatsAlreadyBooked(int capacity, int numberOfSeatBooked)
    {
        var travelRepository = new Mock<ITravelRepository>();
        travelRepository
            .Setup(x => x.GetTravelByIdAsync(1))
            .ReturnsAsync(new Train(capacity, numberOfSeatBooked));

        _bookingContext.TravelRepository = travelRepository;
    }

    [When(@"I book without passenger")]
    public async Task WhenIBookWithoutPassenger()
    {
        try
        {
            var bookingCandidate =
                new BookingCandidate(1, "emaikl@email", new List<Passenger>());

            var bookingAppService = new BookingApplicationService(
                Mock.Of<ITravelRepository>(),
                Mock.Of<IBookingRepository>());

            await bookingAppService.BookAsync(bookingCandidate);
        }
        catch (Exception ex)
        {
            _bookingContext.ActualException = ex;
        }
    }

    [When(@"I book a travel for these passengers")]
    public async Task WhenIBookATravelForThesePassengers(Table table)
    {
        var passengers =
            table.CreateSet<PassengerTable>()
                .Select(x => new Passenger(x.FirstName, x.LastName, x.BirthDate))
                .ToList().AsReadOnly();

        try
        {
            var bookingCandidate = new BookingCandidate(1, "email@email", passengers);

            var bookingAppService = new BookingApplicationService(
                _bookingContext.TravelRepository.Object,
                _bookingContext.BookingRepository.Object);

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
        _bookingContext.ActualException.Should().BeOfType<NoPassengerException>();
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