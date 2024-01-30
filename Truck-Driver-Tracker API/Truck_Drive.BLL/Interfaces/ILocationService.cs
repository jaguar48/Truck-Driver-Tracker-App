using Truck_Drive.DAL.Dtos;
using Truck_Drive.DAL.Entities;

namespace Truck_Drive.BLL.Interfaces
{
    public interface ILocationService
    {
        Task<List<Driver>> GetAllDrivers();
        Task<List<Truck>> GetAllTrucks();

        Task<List<DriverLocationDto>> GetDrivers_TrunkCurrentLocation();
        Task<LocationDto> GetTruckLocation(long truckId, long driverId);

        Task<double> GetDistanceFromStaticCoordinate(long truckId, double staticLat, double staticLon);

    }
}