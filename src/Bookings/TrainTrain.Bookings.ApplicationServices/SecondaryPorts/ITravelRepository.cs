using TrainTrain.Bookings.Domain.Models;

namespace TrainTrain.Bookings.ApplicationServices.SecondaryPorts;

public interface ITravelRepository
{
    Task<Train> GetTravelByIdAsync(int travelId);
}
