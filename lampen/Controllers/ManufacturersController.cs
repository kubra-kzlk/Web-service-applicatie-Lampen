using lampen.Models;
using lampen.Services;
using Microsoft.AspNetCore.Mvc;

namespace lampen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ManufacturersController : Controller
    {
        private readonly ManufacturerService _manufacturerService = new();

        [HttpGet]
        public ActionResult<List<Manufacturer>> GetAll() => _manufacturerService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Manufacturer> GetById(int id)
        {
            var manufacturer = _manufacturerService.GetById(id);
            if (manufacturer == null) return NotFound();
            return manufacturer;
        }

    }
}
