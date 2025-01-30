using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Persistence.Repositories
{
    internal class OrdersRepository : IOrdersRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrdersRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
        }

        public async Task AddAsync(Order order)
        {
            _databaseContext.Attach(order);
            await _databaseContext.SaveChangesAsync();
        }

        public async Task<ICollection<Order>> GetAllAsync()
        {
            return await _databaseContext.Orders.Include(o => o.Items)
                                                .ThenInclude(o => o.Product)
                                                .ToListAsync();
        }

        public async Task<Order?> GetAsync(Guid id)
        {
            return await _databaseContext.Orders.Include(o => o.Items)
                                                .ThenInclude(o => o.Product)
                                                .FirstOrDefaultAsync(o => o.Id == id);
        }

        public async Task UpdateAsync(Order order)
        {
            _databaseContext.Orders.Update(order);
        }
    }
}
