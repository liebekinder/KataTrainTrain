using FluentAssertions;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.Domain.Tests;
public sealed class CarriageTests
{
    [Theory]
    [InlineData(0)]
    [InlineData(-10)]
    public void GivenZeroOrNegativeCapacity_ShouldThrowException(int capacity)
    {
        // Act
        Action act = () => new Carriage(capacity, 6);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenNegativeSeatTakenNumber_ShouldThrowException()
    {
        // Act
        Action act = () => new Carriage(10, -6);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenSeatTakenNumberGreaterThanCapacity_ShouldThrowException()
    {
        // Act
        Action act = () => new Carriage(10, 12);

        // Assert
        act.Should().Throw<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void GivenAllSeatsAvailable_ShouldBeOk()
    {
        // Act
        Action act = () => new Carriage(10, 0);

        // Assert
        act.Should().NotThrow();
    }

    [Theory]
    [InlineData(10, 1)]
    [InlineData(7, 1)]
    [InlineData(6, 2)]
    [InlineData(5, 4)]
    [InlineData(0, 8)]
    public void GivenNewNumberOfSeatExceedCapacity_ShouldReturnTrue(int takenSeats, int numberOfPassager)
    {
        // Arrange
        var carriage = new Carriage(10, takenSeats);

        // Act
        var actual = carriage.IsCapacityExceeded(numberOfPassager, 0.7m);

        // Assert
        actual.Should().BeTrue();
    }

    [Theory]
    [InlineData(7, 0)]
    [InlineData(6, 1)]
    [InlineData(5, 2)]
    [InlineData(0, 7)]
    public void GivenNewNumberOfSeatNotExceedCapacity_ShouldReturnFalse(int takenSeats, int numberOfPassager)
    {
        // Arrange
        var carriage = new Carriage(10, takenSeats);

        // Act
        var actual = carriage.IsCapacityExceeded(numberOfPassager, 0.7m);

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [InlineData(100, 1)]
    [InlineData(70, 1)]
    [InlineData(69, 2)]
    [InlineData(68, 5)]
    public void GivenNewNumberOfSeatExceedCapacityOf100_ShouldReturnTrue(int takenSeats, int numberOfPassager)
    {
        // Arrange
        var carriage = new Carriage(100, takenSeats);

        // Act
        var actual = carriage.IsCapacityExceeded(numberOfPassager, 0.7m);

        // Assert
        actual.Should().BeTrue();
    }

    [Theory]
    [InlineData(69, 1)]
    [InlineData(68, 2)]
    [InlineData(0, 70)]
    [InlineData(45, 10)]
    public void GivenNewNumberOfSeatNotExceedCapacityOf100_ShouldReturnFalse(int takenSeats, int numberOfPassager)
    {
        // Arrange
        var carriage = new Carriage(100, takenSeats);

        // Act
        var actual = carriage.IsCapacityExceeded(numberOfPassager, 0.7m);

        // Assert
        actual.Should().BeFalse();
    }

    [Theory]
    [InlineData(100, 1.0)]
    [InlineData(90, 0.9)]
    [InlineData(70, 0.7)]
    [InlineData(54, 0.5)]
    [InlineData(0, 0.0)]
    public void GivenNewNumberOfSeatNotExceedThreshold_ShouldReturnFalse(int takenSeats, decimal ratio)
    {
        // Arrange
        var carriage = new Carriage(100, takenSeats);

        // Act
        var actual = carriage.IsCapacityExceeded(1, ratio);

        // Assert
        actual.Should().BeFalse();
    }
}