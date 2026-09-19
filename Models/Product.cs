using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUD.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Name is required")]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "Name must be between 3 and 20 characters")]
        public string Name { get; set; } = string.Empty;

        [StringLength(100, MinimumLength = 1, ErrorMessage = "Description cannot exceed 100 characters")]
        public string? Description { get; set; }

        [Range(0.01, 100000, ErrorMessage = "Price must be greater than 0")]
        [Column(TypeName = "decimal(18,2)")] 
        public decimal Price { get; set; }

        [Range(1, 5, ErrorMessage = "Rate must be between 1 and 5")]
        public int Rate { get; set; }
    }
}
