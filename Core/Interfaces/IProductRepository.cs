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
        Task<IEnumerable<Product>> GetProductsByProductTypeIdAsync(string productTypeId, int pageSize, int pageNumber, string sort);
        Task<Product> GetProductByIdAsync(Guid productId);
        Task<IEnumerable<Product>> GetProductListBySearchingAsync(string keyword, int pageSize, int pageNumber, string sort);
        void AddProduct(Product product);
        void DeleteProduct(Product product);

        Task<IEnumerable<ProductType>> GetProductTypes(int level, string parentId);
        // Task<IEnumerable<ProductType>> GetProductTypesLevel0Async(int level);
        // Task<IEnumerable<ProductType>> GetProductTypesLevel1ByPanentIdAsync(int level, string parentId);
        Task<bool> SaveAsync();
    }
}