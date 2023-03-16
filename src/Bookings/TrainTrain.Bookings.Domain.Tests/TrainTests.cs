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
        Action act = () => new Train(-10, 2);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenNegativeNumberOfSeats_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () => new Train(10, -2);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenNumberOfBookedSeatGreaterThanCapacity_ShouldThrowArgumentException()
    {
        // Arrange

        // Act
        Action act = () => new Train(10, 12);

        // Assert
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void GivenNumberOfBookedSeatEqualsToCapacity_ShouldBeOK()
    {
        // Arrange

        // Act
        var train = new Train(10, 10);

        // Assert
        train.Should().NotBeNull();
    }

    [Fact]
    public void GivenNewNumberOfSeatExceedCapacity_ShouldREturnTrue()
    {
        // Arrange
        var train = new Train(10, 10);

        // Act
        var actual = train.IsCapacityExceeded(1, 0.7m);

        // Assert
        actual.Should().BeTrue();
    }
}