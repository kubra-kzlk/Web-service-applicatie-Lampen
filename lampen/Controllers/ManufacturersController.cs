using lampen.Models;
using lampen.Services;
using Microsoft.AspNetCore.Mvc;

namespace lampen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : Controller
    {
        private readonly IManufacturerData _manufacturerService;
        public ManufacturersController(IManufacturerData manufacturerService)
        {
            _manufacturerService = manufacturerService;
        }

        [HttpGet]
        [Route("/api/manufacturers")]
        public async Task<ActionResult<List<Manufacturer>>> GetAllManufacturers()
        {
            var manufacturers = await _manufacturerService.GetAllManufacturers();
            return Ok(manufacturers);
        }

        [HttpGet]
        [Route("/api/manufacturers/{id}")]
        public async Task<ActionResult<Manufacturer>> GetManufacturerById(int id)
        {
            var manufacturer = await _manufacturerService.GetManufacturerById(id);
            if (manufacturer == null)
            {
                return NotFound();
            }
            return Ok(manufacturer);
        }

        [HttpPost]
        [Route("/api/manufacturers/create")] 
        public async Task<ActionResult>? CreateManufacturer(Manufacturer newManufacturer)
        {
            // Check if model is valid
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);  // Return 400 with validation errors
            }

            // Add the manufacturer
            await _manufacturerService.CreateManufacturer(newManufacturer);

            // Return Created response
            return CreatedAtAction(nameof(GetManufacturerById), new { id = newManufacturer.Id }, newManufacturer);

        }
        
        [HttpPut]
        [Route("/api/manufacturers/{id}")]
        public async Task<ActionResult> UpdateManufacturer(int id, [FromBody] Manufacturer updatedManufacturer)
        {
            // Validate model
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var manufacturer = await _manufacturerService.GetManufacturerById(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            // Update manufacturer
            manufacturer.Name = updatedManufacturer.Name;
            manufacturer.Country = updatedManufacturer.Country;
            manufacturer.Description = updatedManufacturer.Description;

            await _manufacturerService.UpdateManufacturer(manufacturer);

            return NoContent();  // 204 No Content on successful update
        }

        [HttpDelete]
        [Route("/api/manufacturers/{id}")]
        public async Task<ActionResult> DeleteManufacturer(int id)
        {
            var manufacturer = await _manufacturerService.GetManufacturerById(id);
            if (manufacturer == null)
            {
                return NotFound();
            }

            await _manufacturerService.DeleteManufacturer(id);

            return NoContent();  // 204 No Content on successful deletion
        }


    }
}
