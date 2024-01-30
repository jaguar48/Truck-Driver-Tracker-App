using Microsoft.AspNetCore.Http.Features;
using Microsoft.EntityFrameworkCore;
using Truck_Drive.BLL.Implementations;
using Truck_Drive.BLL.Interfaces;
using Truck_Drive.DAL;

namespace Truck_Drive.Extension
{
    public static class ServiceExtension
    {

        public static void ConfigureIISIntegration(this IServiceCollection services) =>
      services.Configure<IISOptions>(options =>
      {

      });
        public static void ConfigureSqlContext(this IServiceCollection services, IConfiguration configuration) =>
        services.AddDbContext<TruckDriveDBContext>(opts =>
        opts.UseSqlServer(configuration.GetConnectionString("sqlConnection")));

        public static void ConfigureServices(this IServiceCollection services)
        {
            services.Configure<FormOptions>(options =>
            {
                options.ValueLengthLimit = int.MaxValue;
                options.MultipartBodyLengthLimit = int.MaxValue;
                options.MemoryBufferThreshold = int.MaxValue;
            });

            services.AddScoped<ICsvImportService, CsvImportService>();

            services.AddScoped<ILocationService ,LocationService >();
        }
    }

   
}
