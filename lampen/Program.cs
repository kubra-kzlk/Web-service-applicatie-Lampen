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

            var InMemoryDatabase = builder.Configuration.GetValue<bool>("InMemoryDatabase");
            if (InMemoryDatabase)
            {
                // Register interfaces and services
                builder.Services.AddSingleton<ILampData, InMemoryLampData>();
                builder.Services.AddSingleton<IManufacturerData, ManufacturerService>();
                builder.Services.AddSingleton<IStyleData, StyleService>();
            }
            else
            {
                builder.Services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });
                builder.Services.AddSingleton<ILampData, InMemoryLampData>();
                builder.Services.AddSingleton<IManufacturerData, ManufacturerService>();
                builder.Services.AddSingleton<IStyleData, StyleService>();
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
