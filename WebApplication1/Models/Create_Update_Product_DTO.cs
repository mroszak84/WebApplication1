using System.ComponentModel.DataAnnotations;

namespace WebApplication1.Models
{
    public record Create_Update_Product_DTO
    {
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
