using FluentAssertions;
using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.Domain.Tests;

public class TrainTests
{
    [Fact]
    public void GivenNegativeCapacity_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () => new Train(new[] { new Carriage(-10, 2) });

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenNegativeNumberOfSeats_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () => new Train(new[] { new Carriage(10, -2) });

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenNumberOfBookedSeatGreaterThanCapacity_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () => new Train(new[] { new Carriage(10, 12) });

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenNumberOfBookedSeatEqualsToCapacity_ShouldBeOK()
    {
        // Arrange

        // Act
        var train = new Train(new[] { new Carriage(10, 10) });

        // Assert
        train.Should().NotBeNull();
    }

    [Fact]
    public void GivenATrainWithoutCarriages_ShouldThrowError()
    {
        // Arrange
        var carriages = Array.Empty<Carriage>();

        // Act
        Action act = () => new Train(carriages);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenTwoEmptyCarriage_ShouldReturnFalse()
    {
        // Arrange
        var train = new Train(
            new[] {
                new Carriage(10, 0),
                new Carriage(50, 0),
            });

        // Act
        var actual = train.IsCapacityExceeded(1, 1.0m);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void GivenOneEmptyAndOneFullCarriage_ShouldReturnFalse()
    {
        // Arrange
        var train = new Train(
            new[] {
                new Carriage(30, 0),
                new Carriage(60, 60),
            });

        // Act
        var actual = train.IsCapacityExceeded(1, 0.3m);

        // Assert
        actual.Should().BeFalse();
    }

    [Fact]
    public void GivenTwoFullCarriage_ShouldReturnTrue()
    {
        // Arrange
        var train = new Train(
            new[] {
                new Carriage(54, 54),
                new Carriage(10, 10),
            });

        // Act
        var actual = train.IsCapacityExceeded(1, 0.7m);

        // Assert
        actual.Should().BeTrue();
    }

    [Fact]
    public void GivenTwoCarriageAtRatioCapacity_ShouldReturnTrue()
    {
        // Arrange
        var train = new Train(
            new[] {
                new Carriage(10, 7),
                new Carriage(40, 28),
            });

        // Act
        var actual = train.IsCapacityExceeded(1, 0.7m);

        // Assert
        actual.Should().BeTrue();
    }
}