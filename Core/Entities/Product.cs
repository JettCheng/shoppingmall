using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities
{
    public class Product : BaseEntity
    {
        [Key]
        public Guid Id { get; set; }
        
        [MaxLength(50)]
        public string Title { get; set; }

        [MaxLength(255)]
        public string Description { get; set; }

        [ForeignKey("ProductTypeId")]
        public string ProductTypeId { get; set; }

        public ProductType ProductType { get; set; }
        
        public double OriginalPrice { get; set; }

        public ProductStatus Status { get; set; }
        
        public string CoverImage { get; set; }    // 商品封面

        public ICollection<ProductImage> ProductImages { get; set; } = new List<ProductImage>();
    }

    public enum ProductStatus
    {
        Remove,
        SoldOut,
        Using
    }
}