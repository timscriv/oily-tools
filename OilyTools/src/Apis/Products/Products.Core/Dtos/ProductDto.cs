using System.ComponentModel.DataAnnotations;

namespace Products.Core.Dtos
{
    public class ProductDto
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        [Range(1, 1000, ErrorMessage = "Price must be between $1 and $1000")]
        public decimal Price { get; set; }
    }
}
