using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Core.Entities.OrderAggregate
{
    public class OrderItem : BaseEntity
    {
        public OrderItem()
        {
        }

        // public OrderItem(ProductItemOrdered itemOrdered, double price, int quantity)
        public OrderItem(Guid productId, string productTitle, string coverImage, double price, int quantity)
        {
            // ItemOrdered = itemOrdered;
            ProductId = productId;
            ProductTitle = productTitle;
            CoverImage = coverImage;
            Price = price;
            Quantity = quantity;
        }

        // [Key]    
        // [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        // public int Id { get; set; }
        // public virtual ProductItemOrdered ItemOrdered { get; set; }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string CoverImage { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}