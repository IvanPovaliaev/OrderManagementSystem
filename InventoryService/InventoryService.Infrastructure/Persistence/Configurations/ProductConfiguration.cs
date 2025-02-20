﻿using InventoryService.Domain.Models;
using InventoryService.Infrastructure.Persistence.Builders;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;

namespace InventoryService.Infrastructure.Persistence.Configurations
{
    /// <summary>
    /// Configuration for the <see cref="Product"/> entity.
    /// </summary>
    internal class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        /// <summary>
        /// Configures the <see cref="Product"/> entity in the database context.
        /// </summary>
        /// <param name="builder">The object used for configuring the entity.</param>
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Price)
                   .HasPrecision(18, 2);

            var firstProduct = new ProductBuilder(new Guid("11ea3f23-f3d7-4834-ab3d-247f41517da2"))
                                .WithName("SSD 1Tb ADATA Legend 900 (SLEG-900-1TCS)")
                                .WithArticle("SLEG-900-1TCS")
                                .WithDescription("Накопитель SSD 1Tb ADATA Legend 900 (SLEG-900-1TCS) - это высококачественное хранилище данных для вашего компьютера")
                                .WithPrice(7970)
                                .WithQuantityInStock(20)
                                .Build();

            var secondProduct = new ProductBuilder(new Guid("4cc140dc-410b-4a1f-8e57-8c11c8debe8d"))
                                .WithName("4Tb SATA-III WD Purple (WD43PURZ)")
                                .WithArticle("WD43PURZ")
                                .WithPrice(11020)
                                .WithQuantityInStock(2)
                                .Build();

            builder.HasData(
                firstProduct,
                secondProduct);
        }
    }
}
