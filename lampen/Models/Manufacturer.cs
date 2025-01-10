using System.ComponentModel.DataAnnotations;

namespace lampen.Models
{
    public class Manufacturer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; } = string.Empty;

        public string Country { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;
    }

}
