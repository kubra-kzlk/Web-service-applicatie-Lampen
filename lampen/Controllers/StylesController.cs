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
        [Route("/api/styles")]
        public async Task<ActionResult> GetAllStyles()
        {
            var styles = _styleService.GetAllStyles();
            return Ok(styles);
        }

        [HttpGet]
        [Route("api/styles/{id}")]
        public async Task<ActionResult> GetStyleById(int id)
        {
            var style = await _styleService.GetStyleById(id);
            if (style == null) return NotFound();
            return Ok(style);
        }

        [HttpPost]
        [Route("/api/styles/create")]
        public async Task<ActionResult>? CreateStyle(Style newStyle)
        {
            if (!ModelState.IsValid)// Check if model is valid
            {
                return BadRequest(ModelState);  // Return 400 with validation errors
            }

            // Add the style
            await _styleService.CreateStyle(newStyle);

            // Return Created response
            return CreatedAtAction(nameof(GetStyleById), new { id = newStyle.Id }, newStyle);

        }

        [HttpPut]
        [Route("api/styles/{id}")]
        public async Task<ActionResult> UpdateStyle(int id, [FromBody] Style updatedStyle)
        {
            if (!ModelState.IsValid) // Validate model
            {
                return BadRequest(ModelState);
            }

            var styleUpdate = await _styleService.GetStyleById(id);
            if (styleUpdate == null)
            {
                return NotFound();
            }
            // Update style
            styleUpdate.Name = updatedStyle.Name;
            styleUpdate.Description = updatedStyle.Description;
            await _styleService.UpdateStyle(styleUpdate);
            return NoContent();  // 204 No Content on successful update
        }

        [HttpDelete]
        [Route("api/styles/{id}")]
        public async Task<ActionResult> DeleteStyle(int id)
        {
            var style = await _styleService.GetStyleById(id);
            if (style == null)
            {
                return NotFound();
            }
            await _styleService.DeleteStyle(id);
            return NoContent();  // 204 No Content on successful deletion
        }

    }

}
