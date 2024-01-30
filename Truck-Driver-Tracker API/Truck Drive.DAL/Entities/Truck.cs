using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Threading.Tasks;

namespace Truck_Drive.DAL.Entities
{
    public class Truck
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public long SiteId { get; set; }
        public long AssetId { get; set; }
        public string RegistrationNumber { get; set; }
        public DateTime LastPositionTimestamp { get; set; }
        public double Latitude { get; set; }
        public double Longitute { get; set; }
      
        public string CurrentAddress { get; set; }
    }
}
