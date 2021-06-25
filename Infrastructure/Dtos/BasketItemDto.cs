using System.ComponentModel.DataAnnotations;

namespace API.Dtos
{
    public class BasketItemDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string ProductTitle { get; set; }

        [Required]
        [Range(0.1, double.MaxValue, ErrorMessage = "價格必須大於 0 ")]
        public decimal Price { get; set; }

        [Required]
        [Range(1, double.MaxValue, ErrorMessage = "數量必須大於 1")]
        public int Quantity { get; set; }

        [Required]
        public string CoverImage { get; set; }

        [Required]
        public string ProductType { get; set; }
    }
}