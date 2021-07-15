using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core.Entities;

namespace Core.Interfaces
{
    public interface IProductRepository
    {
        Task<bool> ProductExistAsync(Guid productId);
        Task<IPaginationList<Product>> GetAllProductsAsync(int pageSize, int pageIndex, string sort);
        Task<IEnumerable<Product>> GetProductsByProductTypeIdAsync(string productTypeId, int pageSize, int pageIndex, string sort);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<IPaginationList<Product>> GetProductsAsync(string keyword, string productTypeId, int pageSize, int pageNumber, string sort);
        void AddProduct(Product product);
        void DeleteProductById(Product product);

        Task<IEnumerable<ProductType>> GetProductTypesAsync();


        // Task<IEnumerable<ProductType>> GetProductTypes(int level, string parentId);
        // Task<IEnumerable<ProductType>> GetProductTypesLevel0Async(int level);
        // Task<IEnumerable<ProductType>> GetProductTypesLevel1ByPanentIdAsync(int level, string parentId);
        Task<bool> SaveAsync();
    }
}