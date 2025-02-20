﻿using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Persistence.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InventoryService.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Order"/> entity.
    /// </summary>
    internal class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        /// <summary>
        /// Configures the <see cref="Order"/> entity in the database context.
        /// </summary>
        /// <param name="builder">The object used for configuring the entity.</param>
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.Property(p => p.TotalPrice)
                   .HasPrecision(18, 2);

            var firstOrder = new OrderBuilder(new Guid("af4ed62e-f786-487e-9149-73810453a833"),
                                              new DateTime(2025, 1, 26, 0, 0, 0, DateTimeKind.Utc))
                                            .WithStoreUntil(new DateTime(2025, 2, 26, 0, 0, 0, DateTimeKind.Utc))
                                            .WithStatus(OrderStatus.Created)
                                            .WithClientFullName("Иванов Иван Иванович")
                                            .WithClientPhone("+7900-000-00-00")
                                            .WithTotalItemsCount(2)
                                            .WithTotalPrice(22040)
                                            .Build();

            var secondOrder = new OrderBuilder(new Guid("ee2ca227-74c9-4131-acc0-c25171562598"),
                                               new DateTime(2025, 1, 20, 0, 0, 0, DateTimeKind.Utc))
                                            .WithStoreUntil(new DateTime(2025, 2, 20, 0, 0, 0, DateTimeKind.Utc))
                                            .WithStatus(OrderStatus.Created)
                                            .WithClientFullName("Петров Пётр Петрович")
                                            .WithClientPhone("+7911-111-11-11")
                                            .WithTotalItemsCount(1)
                                            .WithTotalPrice(7970)
                                            .Build();

            builder.HasData(
                firstOrder,
                secondOrder);
        }
    }
}
