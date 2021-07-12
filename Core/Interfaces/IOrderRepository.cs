
using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetOrdersAsync();
        Task<Order> GetOrderByIdAsync(Guid id, string buyerEmail);
        void addOrder(Order order);
        Task<bool> SaveAsync();

    }
}