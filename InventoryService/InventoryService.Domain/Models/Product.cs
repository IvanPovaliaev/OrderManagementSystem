﻿using System;

namespace InventoryService.Domain.Models
{
    public class Product
    {
        public Guid Id { get; init; }
        public string Article { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public int QuantityInStock { get; set; }
    }
}
