using Microsoft.AspNetCore.HttpOverrides;
using Truck_Drive.Contracts;
using Truck_Drive.DAL;
using Truck_Drive.Extension;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.ConfigureIISIntegration();
builder.Services.ConfigureSqlContext(builder.Configuration);

builder.Services.AddControllers();

builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IUnitofWork, UnitOfWork<TruckDriveDBContext>>();

builder.Services.ConfigureServices();
builder.Services.AddHttpContextAccessor();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAnyOrigin",
        builder => builder.AllowAnyOrigin()
                          .AllowAnyMethod()
                          .AllowAnyHeader());
});

var app = builder.Build();

app.UseCors("AllowAnyOrigin");

app.UseHttpsRedirection();

app.UseStaticFiles();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "Truck Drive App v1");
    });
}

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});

app.UseMiddleware<RateLimitingMiddleware>();

app.UseAuthorization();

app.MapControllers();

app.Run();
