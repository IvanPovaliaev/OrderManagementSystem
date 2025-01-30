using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Persistence.Repositories
{
    internal class ProductsRepository : IProductsRepository
    {
        private readonly DatabaseContext _databaseContext;

        public ProductsRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task<ICollection<Product>> GetAllAsync()
        {
            return await _databaseContext.Products.ToListAsync();
        }

        public async Task<Product?> GetAsync(Guid id)
        {
            return await _databaseContext.Products.FindAsync(id);
        }

        public async Task UpdateAsync(Product product)
        {
            _databaseContext.Products.Update(product);
        }
    }
}
