using System;
using System.Collections.Generic;
using Core.Entities.OrderAggregate;

namespace API.Dtos
{
    public class OrderToReturnDto
    {
        public Guid Id { get; set; }
        public string BuyerEmail { get; set; }
        public DateTimeOffset OrderDate { get; set; }
        public Address ShipToAddress { get; set; }
        public string DeliveryMethod { get; set; }
		public double ShippingPrice { get; set; }
        public ICollection<OrderItemDto> OrderItems { get; set; }
        public double Subtotal { get; set; }
        public string Status { get; set; }
        public double Total { get; set; } = 0;// 可以目標可少不可以多（乾脆沒目標最好），不然目標多出來未被映射到就會當掉
    }
}