using lampen.Services;
using lampen.Data;
using Microsoft.AspNetCore.Cors.Infrastructure;
using System;
using Microsoft.EntityFrameworkCore;

namespace lampen
{
    public class Program
    {   //DI, middleware, DB
        public static void Main(string[] args)
        {
            //SERVICE CONFIG
            var builder = WebApplication.CreateBuilder(args);
            // Add services to the container.
            builder.Services.AddControllers(); //mog om API-endpoints aan te maken
            builder.Services.AddEndpointsApiExplorer(); //set up Swagger for API docu API-endpoints verkennen
            builder.Services.AddSwaggerGen(); //set up Swagger for API docu

            //CONDITIONAL SERVICE REGISTRATION (bplt of app in-memo db / sql db)
            // get value of InMemoryDatabase setting from appsettings.json
            var InMemoryDatabase = builder.Configuration.GetValue<bool>("InMemoryDatabase");
            //in-memory db
            if (InMemoryDatabase) //if true:  
            {   //in-memo implementaties w geregis met AddSingleton (1 instantie vdeze service w gemkt en gedeeld)             
                builder.Services.AddSingleton<ILampData, InMemoryLampData>(); //ILampData  uses InMemoryLampData
                builder.Services.AddSingleton<IManufacturerData, ManufacturerService>();
                builder.Services.AddSingleton<IStyleData, StyleService>();
            }
            //SQL server db
            else
            {    //configures Entity Framework Core to use SQL Server
                // Register SQL Server implementations using DatabaseContext
                builder.Services.AddDbContext<DatabaseContext>(options =>
                {
                    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
                });// Register the services to work with the actual db with AddScoped ( vr elke HTTP-aanroep w n nieuwe instantie vdeze services aangemkt)
                builder.Services.AddScoped<ILampData, LampServiceDb>();
                builder.Services.AddScoped<IManufacturerData, ManufacturerServiceDb>();
                builder.Services.AddScoped<IStyleData, StyleServiceDb>();
            }


            //MIDDLEWARE PIPELINE CONFIG
            var app = builder.Build();
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger(); //enable Swagger UI for API docu
                app.UseSwaggerUI();
            }
            app.UseHttpsRedirection();
            app.UseAuthorization(); //adds authorization middleware
            app.MapControllers(); //routing: maps attribute-routed controllers to the request pipeline

            //LOGGING CONFIG
            var logger = app.Services.GetRequiredService<ILogger<Program>>(); //logberichten schrijven
            if (InMemoryDatabase)
            {
                logger.LogInformation("Using InMemory database.");
            }
            else
            {
                logger.LogInformation("Using SQL database.");
            }

            app.Run(); //app opstarten
        }
    }
}
