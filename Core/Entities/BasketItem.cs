using System;

namespace Core.Entities
{
    public class BasketItem
    {
        public Guid ProductId { get; set; }
        
        public string ProductTitle { get; set; }
        
        public double Price { get; set; }
        
        public int Quantity { get; set; }
        
        public string CoverImage { get; set; }
        
        public string ProductType { get; set; }
        
        
    }
}