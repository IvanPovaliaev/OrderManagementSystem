using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using RepositoryService.Domain.Models;
using System;

namespace RepositoryService.Infrastructure.Persistence.Configurations
{
    internal class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.Property(p => p.UnitPrice)
                   .HasPrecision(18, 2);

            var firstOrderItem = new OrderItem()
            {
                Id = new Guid("8a9215b6-705c-451f-a2c4-bdd643d74a7a"),
                OrderId = new Guid("af4ed62e-f786-487e-9149-73810453a833"),
                ProductId = new Guid("4cc140dc-410b-4a1f-8e57-8c11c8debe8d"),
                UnitPrice = 11020,
                Quantity = 2
            };

            var secondOrderItem = new OrderItem()
            {
                Id = new Guid("d6dac720-bd3b-460c-8757-2cd9398882ed"),
                OrderId = new Guid("ee2ca227-74c9-4131-acc0-c25171562598"),
                ProductId = new Guid("11ea3f23-f3d7-4834-ab3d-247f41517da2"),
                UnitPrice = 7970,
                Quantity = 1
            };

            builder.HasData(
                firstOrderItem,
                secondOrderItem);
        }
    }
}
