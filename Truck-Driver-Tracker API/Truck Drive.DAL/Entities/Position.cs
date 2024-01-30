using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Drive.DAL.Entities
{
    public class Position
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public int AgeOfReadingSeconds { get; set; }
        public long AssetId { get; set; }
       /* public Truck Truck { get; set; }*/
        public double AltitudeMetres { get; set; }
        
        public int Heading { get; set; }
        public long DriverId { get; set; }
        public double Latitude { get; set; }
        public bool IsAvl { get; set; }
        public double OdometerKilometres { get; set; }
        public double Longitude { get; set; }
        public double Hdop { get; set; }
        public long PositionId { get; set; }
        public double Pdop { get; set; }
        public DateTime TimeStamp { get; set; }
        public string Source { get; set; }
        public double SpeedKilometresPerHour { get; set; }
        public int SpeedLimit { get; set; }
        public double Vdop { get; set; }

    }
}
