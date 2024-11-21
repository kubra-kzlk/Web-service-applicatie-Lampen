﻿using lampen.Models;
using lampen.Services;
using Microsoft.AspNetCore.Mvc;

namespace lampen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LampsController : Controller
    {
        private readonly ILampData _lampService;

        // Constructor to inject services
        //Inject the services via Dependency Injection (DI) instead of creating new instances directly inside the controllers.
        public LampsController(ILampData lampService)
        { //Inject the interfaces (ILampData, IManufacturerData, IStyleData) in the controller constructor.
            _lampService = lampService;
        }
        //Change method signatures to use async and await for asynchronous operations, based on your service methods that return Task<T>
        [HttpGet]
        [Route("/api/lamps")]
        public async Task<ActionResult<List<Lamp>>> GetAllLamps()
        {
            var lamps = await _lampService.GetAllLamps();
            return Ok(lamps);
        }

        [HttpGet]
        [Route("/api/lamps/{id}")]
        public async Task<ActionResult<object>> GetLampById(int id)
        {
            var lamp = await _lampService.GetLampById(id);
            if (lamp == null) return NotFound();
            return new
            {
                Lamp = lamp
            };
        }

        [HttpPost]
        [Route("/api/lamps/create")]
        public async Task<ActionResult>? CreateLamp(Lamp newLamp)
        {
            //Wanneer de client ongeldige gegevens probeert te posten, willen we een HTTP Status Code 400 (Bad Request) retourneren. Dit kan door de ingebouwde validatie van ASP.NET Core te gebruiken.
            //We kunnen de ModelState.IsValid controle gebruiken in de actie die verantwoordelijk is voor het maken van entiteiten.Wanneer de validatie mislukt, sturen we een BadRequest met de validatiefouten.
            // Controleer de validatie van het model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // Dit stuurt de validatiefouten terug
            }
            if (newLamp == null)
            {
                return BadRequest("Lamp cannot be null");
            }

            await _lampService.CreateLamp(newLamp);
            return Ok();
        }

        [HttpPut]
        [Route("/api/lamps/{id}")]
        public async Task<ActionResult> UpdateLamp(int id, [FromBody] Lamp updatedLamp)
        {
            // Validatie van het model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var lamp = await _lampService.GetLampById(id);
            if (lamp == null)
            {
                return NotFound();
            }

            // Werk de lamp bij met de nieuwe gegevens
            lamp.Name = updatedLamp.Name;
            lamp.Description = updatedLamp.Description;
            lamp.Price = updatedLamp.Price;
            lamp.IsActive = updatedLamp.IsActive;
            lamp.Date = updatedLamp.Date;
            lamp.Photo = updatedLamp.Photo;
            lamp.Color = updatedLamp.Color;
            lamp.ManufacturerId = updatedLamp.ManufacturerId;
            lamp.StyleIds = updatedLamp.StyleIds;
            await _lampService.UpdateLamp(lamp); // Update service aanroepen
            return NoContent(); // Geeft 204 No Content terug als de update succesvol is
        }

        [HttpDelete]
        [Route("api/lamps/{id}")]
        public async Task<ActionResult> DeleteLamp(int id)
        {
            var lamp = await _lampService.GetLampById(id);
            if (lamp == null)
            {
                return NotFound();
            }

            await _lampService.DeleteLamp(id); // Verwijder service aanroepen

            return NoContent(); // Geeft 204 No Content terug als de delete succesvol is
        }


    }

}
