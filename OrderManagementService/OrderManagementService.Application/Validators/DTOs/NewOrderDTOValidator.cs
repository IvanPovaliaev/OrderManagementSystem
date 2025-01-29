using FluentValidation;
using OrderManagementService.Application.Models.DTOs;

namespace OrderManagementService.Application.Validators.DTOs
{
    public class NewOrderDTOValidator : AbstractValidator<NewOrderDTO>
    {
        public NewOrderDTOValidator()
        {
            RuleFor(newOrder => newOrder.ClientFullName)
                .NotEmpty()
                .NotNull();

            RuleFor(newOrder => newOrder.ClientPhone)
                .NotEmpty()
                .NotNull();

            RuleFor(newOrder => newOrder.Items)
                .NotEmpty()
                .NotNull();

            RuleForEach(order => order.Items)
                .SetValidator(new OrderItemDTOValidator());
        }
    }
}
