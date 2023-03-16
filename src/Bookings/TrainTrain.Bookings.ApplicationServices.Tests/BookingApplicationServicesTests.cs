using FluentAssertions;
using Moq;
using TrainTrain.Bookings.ApplicationServices.Exceptions;
using TrainTrain.Bookings.ApplicationServices.PrimaryPorts;
using TrainTrain.Bookings.ApplicationServices.SecondaryPorts;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.Tests;

public class BookingApplicationServicesTests
{
    private readonly IBookingApplicationService _bookingApplicationService;
    private readonly Mock<ITravelRepository> _travelRepository;
    private readonly Mock<IBookingRepository> _bookingRepository;

    public BookingApplicationServicesTests()
    {
        _travelRepository = new Mock<ITravelRepository>();
        _bookingRepository = new Mock<IBookingRepository>();

        _bookingApplicationService = new BookingApplicationService(
            _travelRepository.Object,
            _bookingRepository.Object);
    }

    [Fact]
    public async Task BookAsync_GivenNoPassenger_ShouldThrowNoPassengerException()
    {
        // Arrange
        var bookCandidate = new BookingCandidate(travalId: 0, email: "Test@lucca.fr", passengers: new List<Passenger>());

        // Act
        Func<Task> actual = async () => await _bookingApplicationService.BookAsync(bookCandidate);

        // Assert
        await actual.Should().ThrowAsync<NoPassengerException>();
    }

    [Fact]
    public async Task BookAsync_GivenTrainNotFound_ShouldThrowTrainNotFoundException()
    {
        // Arrange
        var passengers = new List<Passenger>() { new Passenger("nom", "prenom", new DateOnly(1990, 01, 01)) };
        var booking = new BookingCandidate(1, "email@ami", passengers);

        // Act
        Func<Task> actual = async () => await _bookingApplicationService.BookAsync(booking);

        // Assert
        await actual.Should().ThrowAsync<TrainNotFoundException>();
    }

    [Fact]
    public async Task BookAsync_GivenTrainFull_ShouldThrowTrainFullException()
    {
        // Arrange
        var passengers = new List<Passenger>()
        {
            new Passenger("nom", "prenom", new DateOnly(1990, 01, 01)),
            new Passenger("nom", "prenom", new DateOnly(1990, 01, 01)),
            new Passenger("nom", "prenom", new DateOnly(1990, 01, 01)),
        };
        var booking = new BookingCandidate(1, "email@ami", passengers);

        _travelRepository
            .Setup(x => x.GetTravelByIdAsync(1))
            .ReturnsAsync(new Train(100, 70));

        // Act
        Func<Task> actual = async () => await _bookingApplicationService.BookAsync(booking);

        // Assert
        await actual.Should().ThrowAsync<TrainFullException>();
    }

    [Fact]
    public async Task BookAsync_GivenBooking_ShouldBook()
    {
        // Arrange
        var passengers = new List<Passenger>()
        {
            new Passenger("nom", "prenom", new DateOnly(1990, 01, 01)),
        };
        var booking = new BookingCandidate(1, "email@ami", passengers);

        _travelRepository
            .Setup(x => x.GetTravelByIdAsync(1))
            .ReturnsAsync(new Train(100, 40));

        // Act
        await _bookingApplicationService.BookAsync(booking);

        // Assert
        _bookingRepository
            .Verify(x => x.Book(It.IsAny<Booking>()), Times.Once);
    }
}