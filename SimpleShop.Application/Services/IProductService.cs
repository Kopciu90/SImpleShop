﻿using SimpleShop.Core.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SimpleShop.Application.Interfaces
{
    public interface IProductService
    {
        Task<Product> GetProductByIdAsync(int id);
        Task<IEnumerable<Product>> GetAllProductsAsync();
        Task AddProductAsync(Product product);
        Task UpdateProductAsync(Product product);
        Task DeleteProductAsync(int id);
    }
}
