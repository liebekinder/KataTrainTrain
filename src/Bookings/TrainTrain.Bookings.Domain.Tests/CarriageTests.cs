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
}

