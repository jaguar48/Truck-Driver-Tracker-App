using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.IO;
using System.Threading.Tasks;
using Truck_Drive.BLL.Interfaces;

[ApiController]
[Route("[controller]")]
public class CsvImportController : ControllerBase
{
    private readonly ICsvImportService _csvImportService;

    public CsvImportController(ICsvImportService csvImportService)
    {
        _csvImportService = csvImportService;
    }

    [HttpPost("import")]
    public async Task<IActionResult> ImportCsv(IFormFile file)
    {
        if (file == null || file.Length == 0)
            return BadRequest("Invalid file");

        try
        {

            var filePath = Path.GetTempFileName();
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(stream);
            }


            var fileName = Path.GetFileName(file.FileName);
            if (fileName.Contains("positions", StringComparison.OrdinalIgnoreCase))
            {
                await _csvImportService.ImportPositionCsvDataAsync(filePath);
            }
            else if (fileName.Contains("drivers", StringComparison.OrdinalIgnoreCase))
            {
                await _csvImportService.ImportDriverCsvDataAsync(filePath);
            }
            else if (fileName.Contains("trucks", StringComparison.OrdinalIgnoreCase))
            {
                await _csvImportService.ImportTruckCsvDataAsync(filePath);
            }
            else
            {
                return BadRequest("Unsupported file format");
            }

            return Ok($"CSV data from {fileName} imported successfully.");
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"An error occurred: {ex.Message}");
        }
    }
}
