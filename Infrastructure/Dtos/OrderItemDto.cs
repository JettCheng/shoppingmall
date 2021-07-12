using System;

namespace API.Dtos
{
    public class OrderItemDto
    {
        public Guid ProductId { get; set; }
        public string ProductTitle { get; set; }
        public string CoverImage { get; set; }
        public double Price { get; set; }
        public int Quantity { get; set; }
    }
}