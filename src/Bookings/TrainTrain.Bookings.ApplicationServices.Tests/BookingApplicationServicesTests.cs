using FluentAssertions;
using System.Collections.Generic;
using TrainTrain.Bookings.ApplicationServices.PrimaryPorts;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.Tests;

public class BookingApplicationServicesTests
{
    private readonly IBookingApplicationService _bookingApplicationService;

    public BookingApplicationServicesTests()
    {
        _bookingApplicationService = new BookingApplicationService();
    }

    [Fact]
    public async Task TestWhenThereIsNoPassengerWithTheBook()
    {
        // Arrange
        var bookCandidate = new BookingCandidate(travalId : 0, email: "Test@lucca.fr", passengers: new List<Passenger>());

        // Act
        var actual = await _bookingApplicationService.BookAsync(bookCandidate);

        // Assert
        actual.Should().BeTrue();
    }
}