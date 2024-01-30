using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Drive.DAL.Dtos
{
    public class DriverLocationDto
    {
        public long DriverId { get; set; }
       
        public long TruckId { get; set; }
        public string TruckRegistrationNumber { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime TimeStamp { get; set; }
    }

}
