using FluentValidation;
using OrderManagementService.Application.Models.DTOs;
using System;

namespace OrderManagementService.Application.Validators.DTOs
{
    public class OrderItemDTOValidator : AbstractValidator<OrderItemDTO>
    {
        public OrderItemDTOValidator()
        {
            RuleFor(item => item.ProductId)
                .NotEqual(Guid.Empty)
                .NotNull();

            RuleFor(item => item.Quantity)
                .GreaterThan(0);

            RuleFor(item => item.UnitPrice)
                .GreaterThan(0);
        }
    }
}
