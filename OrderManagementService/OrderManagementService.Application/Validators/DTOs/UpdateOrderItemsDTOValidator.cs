using FluentValidation;
using OrderManagementService.Application.Models.DTOs;
using System;

namespace OrderManagementService.Application.Validators.DTOs
{
    public class UpdateOrderItemsDTOValidator : AbstractValidator<UpdateOrderItemsDTO>
    {
        public UpdateOrderItemsDTOValidator()
        {
            RuleFor(order => order.Id)
                .NotEqual(Guid.Empty)
                .NotNull();

            RuleFor(order => order.Items)
                .NotEmpty()
                .NotNull();

            RuleForEach(order => order.Items)
                .SetValidator(new OrderItemDTOValidator());
        }
    }
}
