using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public record Product_DTO
    {
        [Required]
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Nazwa jest wymagana")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required]
        public int Number { get; set; }
        [Required]
        public int Quantity { get; set; }
        [Required]
        [StringLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "Cena jest wymagana")]
        public decimal Price { get; set; }
    }
}
