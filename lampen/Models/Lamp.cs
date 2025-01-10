using System.ComponentModel.DataAnnotations;

namespace lampen.Models
{
    public class Lamp
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Lamp name is required.")] //[Required] data annotations for validation, velden voldoen aan verwachte vereisten
        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public decimal Price { get; set; }

        public bool IsActive { get; set; }

        public string Date { get; set; } = string.Empty;

        public string Photo { get; set; } = string.Empty;

        [Required(ErrorMessage = "Color is required.")]
        public string Color { get; set; } = string.Empty;

        // Relationships
        [Required(ErrorMessage = "Manufacturer ID is required.")]
        public int ManufacturerId { get; set; }

        [Required(ErrorMessage = "Style IDs are required.")]
        public List<int> StyleIds { get; set; } = new();
    }

}
