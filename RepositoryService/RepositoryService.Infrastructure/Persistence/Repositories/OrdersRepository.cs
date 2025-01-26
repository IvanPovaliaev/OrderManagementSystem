﻿using Microsoft.EntityFrameworkCore;
using RepositoryService.Domain.Interfaces;
using RepositoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace RepositoryService.Infrastructure.Persistence.Repositories
{
    internal class OrdersRepository : IOrdersRepository
    {
        private readonly DatabaseContext _databaseContext;

        public OrdersRepository(DatabaseContext databaseContext)
        {
            _databaseContext = databaseContext;
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
    }
}
