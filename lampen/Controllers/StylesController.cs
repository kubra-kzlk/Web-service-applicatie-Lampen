using lampen.Models;
using lampen.Services;
using Microsoft.AspNetCore.Mvc;

namespace lampen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StylesController : Controller
    {
        private readonly IStyleData _styleService;

        // Constructor to inject service
        public StylesController(IStyleData styleService)
        {
            _styleService = styleService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Style>>> GetAll()
        {
            var styles = await _styleService.GetAllAsync();
            return Ok(styles);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Style>> GetById(int id)
        {
            var style = await _styleService.GetByIdAsync(id);
            if (style == null) return NotFound();
            return style;
        }
    }

}
