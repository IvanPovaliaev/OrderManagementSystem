using FluentValidation;
using OrderManagementService.Application.Models;
using OrderManagementService.Application.Models.DTOs;
using System;

namespace OrderManagementService.Application.Validators.DTOs
{
    public class ChangeOrderStatusDTOValidator : AbstractValidator<ChangeOrderStatusDTO>
    {
        public ChangeOrderStatusDTOValidator()
        {
            RuleFor(changeOrderStatus => changeOrderStatus.Id)
                .NotEqual(Guid.Empty)
                .NotNull();

            RuleFor(changeOrderStatus => changeOrderStatus.NewStatus)
                .NotEqual(OrderStatus.Cancelled)
                .NotNull();
        }
    }
}
