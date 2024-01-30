using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Truck_Drive.BLL.Helpers;
using Truck_Drive.BLL.Interfaces;
using Truck_Drive.Contracts;
using Truck_Drive.DAL.Dtos;
using Truck_Drive.DAL.Entities;

namespace Truck_Drive.BLL.Implementations
{
    public class LocationService : ILocationService
    {

        private readonly IRepository<Driver> _driverRepo;
        private readonly IRepository<Truck> _truckRepo;
        private readonly IUnitofWork _unitOfWork;
        private readonly IRepository<Position> _positionRepo;

        public LocationService(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _positionRepo = _unitOfWork.GetRepository<Position>();
            _driverRepo = _unitOfWork.GetRepository<Driver>();
            _truckRepo = _unitOfWork.GetRepository<Truck>();
        }

        public async Task<List<Driver>> GetAllDrivers()
        {
            var drivers = await _driverRepo.GetAllAsync();
            return drivers.ToList();
        }


        public async Task<List<Truck>> GetAllTrucks()
        {
            var trucks = await _truckRepo.GetAllAsync();
            return trucks.ToList();
        }

      


        public async Task<List<DriverLocationDto>> GetDrivers_TrunkCurrentLocation()
        {
            var positions = await _positionRepo
                .GetAllAsync(
                    filter: p => p.IsAvl
                );

            var driverIds = positions.Select(p => p.DriverId).Distinct().ToList();


            var truckIds = positions.Select(p => p.AssetId).Distinct().ToList();

            var drivers = await _driverRepo
                .GetByAsync(d => driverIds.Contains(d.Id));

            var trucks = await _truckRepo
                .GetByAsync(t => truckIds.Contains(t.AssetId));

            var driverLocations = positions.Select(p => new DriverLocationDto
            {
                DriverId = (long)p.DriverId,
    
                TruckId = (long)p.AssetId,
                TruckRegistrationNumber = trucks.FirstOrDefault(t => t.AssetId == p.AssetId)?.RegistrationNumber,
                Latitude = p.Latitude,
                Longitude = p.Longitude,
                TimeStamp = p.TimeStamp
            }).ToList();


            return driverLocations;
        }


      

        public async Task<LocationDto> GetTruckLocation(long truckId, long driverId)
        {
            var position = await _positionRepo.GetSingleByAsync(
                p => p.AssetId == truckId && p.DriverId == driverId,
                orderBy: q => q.OrderByDescending(p => p.TimeStamp)
            );

            if (position != null)
            {

                var truck = await _truckRepo.GetSingleByAsync(t => t.AssetId == truckId);



                var locationDto = new LocationDto
                {
                    Address = truck?.CurrentAddress,
                    Longitude = truck.Longitute,
                    Latitude = truck.Latitude,
                    LastTimeStamp = truck.LastPositionTimestamp
                };

                return locationDto;
            }

            return null;
        }


        public async Task<double> GetDistanceFromStaticCoordinate(long truckId, double staticLat, double staticLon)
        {
            var position = await _positionRepo.GetSingleByAsync(
                p => p.AssetId == truckId,
                orderBy: q => q.OrderByDescending(p => p.TimeStamp)
            );

            if (position != null)
            {
                var distance = DistanceCaculator.CalculateDistance(position.Latitude, position.Longitude, staticLat, staticLon);
                return distance;
            }

            return double.NaN; 
        }


    }
}