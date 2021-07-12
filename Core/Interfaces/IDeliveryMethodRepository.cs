
using Core.Entities.OrderAggregate;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IDeliveryMethodRepository
    {
        Task<DeliveryMethod> GetDeliveryMethodById (int DeliveryMethodId);

        Task<List<DeliveryMethod>> GetDeliveryMethods();
    }
}