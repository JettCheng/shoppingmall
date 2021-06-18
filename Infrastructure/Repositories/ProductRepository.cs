using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Database.Domain;
using Infrastructure.Dtos;
using Infrastructure.Services;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ProductRepository : IProductRepository
    {
        private readonly AppDbContext _context;
        private readonly IPropertyMappingService _propertyMappingService;
        public ProductRepository(AppDbContext context, IPropertyMappingService propertyMappingService)
        {
            _propertyMappingService = propertyMappingService;
            _context = context;
        }
        public async Task<IPaginationList<Product>> GetAllProductsAsync(int pageSize, int pageIndex, string sort)
        {
            IQueryable<Product> result = _context.Products
                .Include(p => p.ProductType)
                .Include(p => p.ProductImages);
                
            if (!(string.IsNullOrEmpty(sort)))
            {
                // 把兩個需要 mapping 的 class 丟進去，回傳的就是 mapping 成功的屬性對照列表
                var productMappingDictionary = _propertyMappingService.GetPropertyMapping<ProductDto, Product>();

                // 根據屬性對照列表結果將資料進行重新排序
                result = result.ApplySort(sort, productMappingDictionary);
            }
            return await PaginationList<Product>.CreateAsync(pageIndex, pageSize, result);
        }

        public void AddProduct(Product product)
        {
            throw new NotImplementedException();
        }

        public void DeleteProduct(Product product)
        {
            throw new NotImplementedException();
        }


        public Task<Product> GetProductByIdAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductListBySearchingAsync(string keyword, int pageSize, int pageNumber, string sort)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Product>> GetProductsByProductTypeIdAsync(string productTypeId, int pageSize, int pageNumber, string sort)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ProductType>> GetProductTypes(int level, string parentId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> ProductExistAsync(Guid productId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> SaveAsync()
        {
            throw new NotImplementedException();
        }
    }
}