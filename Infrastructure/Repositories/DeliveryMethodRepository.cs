
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities.OrderAggregate;
using Core.Interfaces;
using Infrastructure.Database.Domain;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class DeliveryMethodRepository : IDeliveryMethodRepository
    {
        private readonly AppDbContext _context;
        public DeliveryMethodRepository(AppDbContext context)
        {
            _context = context;

        }
        public Task<DeliveryMethod> GetDeliveryMethodById(int DeliveryMethodId)
        {
            return _context.DeliveryMethods.FirstOrDefaultAsync(dm => dm.Id == DeliveryMethodId);
        }

        public Task<List<DeliveryMethod>> GetDeliveryMethods()
        {
            return  _context.DeliveryMethods.ToListAsync();
        }
    }
}