using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Infrastructure.Repositories;

namespace Infrastructure.Services
{
    public class OrderService : IOrderService
    {

        // private readonly IPaymentService _paymentService;
        private readonly IBasketRepository _basketRepository;
        private readonly IProductRepository _productRepository;
        private readonly IDeliveryMethodRepository _deliveryMethodRepository;
        private readonly IOrderRepository _orderRepository;

        public OrderService(IBasketRepository basketRepository, IProductRepository productRepository, IDeliveryMethodRepository deliveryMethodRepository, IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
            _deliveryMethodRepository = deliveryMethodRepository;
            _productRepository = productRepository;
            _basketRepository = basketRepository;

        }
        public async Task<Order> CreateOrderAsync(string buyerEmail, int delieveryMethodId, string basketId, Address shippingAddress)
        {
            // 從購物車取得客戶欲購買商品之商品編號
            var basketFromRepo = await _basketRepository.GetBasketAsync(basketId);

            // 再拿購物車中商品編號去資料庫撈出該商品完整資訊
            // 並產生訂單
            var orderItems = new List<OrderItem>();
            foreach (var basketItem in basketFromRepo.Items)
            {
                var productItem = await _productRepository.GetProductByIdAsync(basketItem.ProductId);
                // var itemOrdered = new ProductItemOrdered(productItem.Id, productItem.Title, productItem.CoverImage);
                var orderItem = new OrderItem(productItem.Id, productItem.Title, productItem.CoverImage, productItem.OriginalPrice, basketItem.Quantity);
                orderItems.Add(orderItem);
            }

            // get delivery method from repo
            var deliveryMethod = await _deliveryMethodRepository.GetDeliveryMethodById(delieveryMethodId);

            // calc subtotal
            var subtotal = orderItems.Sum(item => item.Price * item.Quantity);

            // check to see if order exists

            // create order
        var newOrder = new Order(orderItems, buyerEmail, shippingAddress, deliveryMethod, subtotal, basketFromRepo.PaymentIntentId);
            _orderRepository.addOrder(newOrder);

            // TODO: save to db
            var result = await _orderRepository.SaveAsync();
            if(!result) return null;

            // return order
            return newOrder;

        }
        public async Task<List<DeliveryMethod>> GetDeliveryMethodsAsync()
        {
            return await _deliveryMethodRepository.GetDeliveryMethods();
        }
        public async Task<Order> GetOrderByIdAsync(Guid id, string buyerEmail)
        {
            return await _orderRepository.GetOrderByIdAsync(id, buyerEmail);
        }

        public async Task<List<Order>> GetOrdersForUserAsync(string buyerEmail)
        {
            return await _orderRepository.GetOrdersAsync();
        }
    }
}