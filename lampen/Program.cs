using lampen.Services;
using lampen.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using Microsoft.EntityFrameworkCore;

namespace lampen
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // Retrieve the value of the InMemoryDatabase setting from appsettings.json
            var InMemoryDatabase = builder.Configuration.GetValue<bool>("InMemoryDatabase");
            if (InMemoryDatabase)
            {
                // Register in-memory implementations
                builder.Services.AddSingleton<ILampData, InMemoryLampData>();
                builder.Services.AddSingleton<IManufacturerData, ManufacturerService>();
                builder.Services.AddSingleton<IStyleData, StyleService>();
            }
            else
            {    // Register SQL Server implementations using DatabaseContext
                builder.Services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });// Register the services to work with the actual database
                builder.Services.AddScoped<ILampData, LampServiceDb>();
                builder.Services.AddScoped<IManufacturerData, ManufacturerServiceDb>();
                builder.Services.AddScoped<IStyleData, StyleServiceDb>();
            }

            
            
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();

            var logger = app.Services.GetRequiredService<ILogger<Program>>();
            if (InMemoryDatabase)
            {
                logger.LogInformation("Using InMemory database.");
            }
            else
            {
                logger.LogInformation("Using SQL database.");
            }
            app.Run();
        }
    }
}
