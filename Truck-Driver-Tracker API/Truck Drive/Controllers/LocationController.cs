using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Truck_Drive.BLL.Helpers;
using Truck_Drive.BLL.Interfaces;
using Truck_Drive.DAL.Entities;

namespace Truck_Drive.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LocationController : ControllerBase
    {
        private readonly ILocationService _locationService;

        public LocationController(ILocationService locationService)
        {
            _locationService = locationService;
        }

        [HttpGet("drivers")]
        public async Task<IActionResult> GetAllDrivers()
        {
            var drivers = await _locationService.GetAllDrivers();
            return Ok(drivers);
        }

        [HttpGet("trucks")]
        public async Task<IActionResult> GetAllTrucks()
        {
            var trucks = await _locationService.GetAllTrucks();
            return Ok(trucks);
        }

        [HttpGet("Truck_Driver_current-location")]
        public async Task<IActionResult> GetDriversCurrentLocation()
        {
            var driverLocations = await _locationService.GetDrivers_TrunkCurrentLocation();
            return Ok(driverLocations);
        }
         
        [HttpGet("location")]
        public async Task<IActionResult> GetLocation(long truckId, long driverId)
        {
            try
            {
               
                var location = await _locationService.GetTruckLocation(truckId, driverId);
                
                if (location != null)
                {
                    
                    return Ok(location);
                }

                return NotFound("Location not found for the provided TruckID and DriverID.");
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }

        [HttpGet("distance")]
        public async Task<IActionResult> CalculateDistance(long truckId, double staticLat, double staticLon)
        {
            try
            {
               
                var distance = await _locationService.GetDistanceFromStaticCoordinate(truckId, staticLat, staticLon);

                if (double.IsNaN(distance))
                {
                    return NotFound("Truck location not found for the provided TruckID.");
                }

                return Ok(distance);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"An error occurred: {ex.Message}");
            }
        }


    }
}
