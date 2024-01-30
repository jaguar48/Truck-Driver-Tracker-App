using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Drive.DAL.Dtos
{
   
        public class LocationDto
        {
            public string Address { get; set; }
            public double Longitude { get; set; }
            public double Latitude { get; set; }
            public DateTime Timestamp { get; set; }
            public DateTime LastTimeStamp { get; set; }
        }

   
}
