using lampen.Models;
using lampen.Services;
using Microsoft.AspNetCore.Mvc;

namespace lampen.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StylesController : Controller
    {
        private readonly StyleService _styleService = new();

        [HttpGet]
        public ActionResult<List<Style>> GetAll() => _styleService.GetAll();

        [HttpGet("{id}")]
        public ActionResult<Style> GetById(int id)
        {
            var style = _styleService.GetById(id);
            if (style == null) return NotFound();
            return style;
        }
    }

}
