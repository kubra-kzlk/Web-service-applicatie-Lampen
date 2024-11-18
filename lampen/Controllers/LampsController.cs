using lampen.Models;
using lampen.Services;
using Microsoft.AspNetCore.Mvc;

namespace lampen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LampsController : Controller
    {
        private readonly LampService _lampService = new();
        private readonly ManufacturerService _manufacturerService = new();
        private readonly StyleService _styleService = new();

        [HttpGet]
        public ActionResult<List<Lamp>> GetAll() => _lampService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<object> GetById(int id)
        {
            var lamp = _lampService.GetById(id);
            if (lamp == null) return NotFound();

            var fabrikant = _manufacturerService.GetById(lamp.FabrikantId);
            var stijlen = _styleService.GetAll().Where(s => lamp.StijlIds.Contains(s.Id)).ToList();

            return new
            {
                Lamp = lamp,
                Fabrikant = fabrikant,
                Stijlen = stijlen
            };
        }
    }

}
