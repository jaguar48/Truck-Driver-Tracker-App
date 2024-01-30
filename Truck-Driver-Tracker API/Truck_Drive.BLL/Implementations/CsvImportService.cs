
using CsvHelper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Truck_Drive.BLL.Interfaces;
using Truck_Drive.Contracts;
using Truck_Drive.DAL.Entities;

public class CsvImportService : ICsvImportService
{
    private readonly IRepository<Position> _positionRepo;
    private readonly IRepository<Driver> _driverRepo;
    private readonly IRepository<Truck> _truckRepo;
    private readonly IUnitofWork _unitOfWork;

    public CsvImportService(IUnitofWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
        _positionRepo = _unitOfWork.GetRepository<Position>();
        _driverRepo = _unitOfWork.GetRepository<Driver>();
        _truckRepo = _unitOfWork.GetRepository<Truck>();
    }

    public async Task ImportPositionCsvDataAsync(string filePath)
    {
        await ImportCsvDataAsync<Position>(filePath, _positionRepo);
    }

    public async Task ImportDriverCsvDataAsync(string filePath)
    {
        await ImportCsvDataAsync<Driver>(filePath, _driverRepo);
    }

    public async Task ImportTruckCsvDataAsync(string filePath)
    {
        await ImportCsvDataAsync<Truck>(filePath, _truckRepo);
    }

    private async Task ImportCsvDataAsync<T>(string filePath, IRepository<T> repository) where T : class
    {
        try
        {
            using (var reader = new StreamReader(filePath))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                var records = csv.GetRecords<T>().ToList();
                await repository.AddRangeAsync(records);
                await _unitOfWork.SaveChangesAsync();
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error importing data from CSV file {filePath}: {ex.Message}");
        }
    }

}
