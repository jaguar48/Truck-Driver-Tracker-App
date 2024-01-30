using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Truck_Drive.BLL.Interfaces
{
    public interface ICsvImportService
    {
        Task ImportPositionCsvDataAsync(string filePath);
        Task ImportDriverCsvDataAsync(string filePath);
        Task ImportTruckCsvDataAsync(string filePath);
    }
}
