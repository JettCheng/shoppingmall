using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Core.Dtos;
using Core.Entities;

namespace Infrastructure.Dtos
{
    public class ProductForCreationDto
    {
        [Required(ErrorMessage = "title is required")]
        [MaxLength(50)]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [MaxLength(200)]
        public string Description { get; set; }
        [Required(ErrorMessage = "ProductTypeId is required")]
        public string ProductTypeId { get; set; }
        [Required(ErrorMessage = "OriginalPrice is required")]
        public double OriginalPrice { get; set; }
        public string CoverImage { get; set; }    // 商品封面
        public ICollection<ProductImageForCreationDto> ProductImages { get; set; }
        
    }
}