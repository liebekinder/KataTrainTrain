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
    private readonly ITravelRepository _travelRepository;

    public BookingApplicationServicesTests()
    {
        _travelRepository = Mock.Of<ITravelRepository>();

        _bookingApplicationService = new BookingApplicationService(_travelRepository);
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
        var booking = new BookingCandidate(1, "email", passengers);

        // Act
        Func<Task> actual = async () => await _bookingApplicationService.BookAsync(booking);

        // Assert
        await actual.Should().ThrowAsync<TrainNotFoundException>();
    }
}