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

    //public async Task BookAsync_GivenNotFoundTravel_ShouldThrowTravelNotFoundException()
    //{
    //    // Arrange
    //    var passengers = new List<Passenger>() { new Passenger("nom", "prenom", new DateOnly(1990, 01, 01)) };
    //    var booking = new BookingCandidate(1, "email", passengers);

    //    // Act
    //    Func<Task> act = async () => await _bookingApplicationService.BookAsync(booking);

    //    // Assert
    //    await act.Should().ThrowAsync<TravelNotFoundException>();
    //}
}