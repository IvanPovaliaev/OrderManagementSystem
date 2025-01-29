using FluentValidation;
using OrderManagementService.Application.Models.Options;

namespace OrderManagementService.Application.Validators.Options
{
    public class OrderOptionsValidator : AbstractValidator<OrdersOptions>
    {
        public OrderOptionsValidator()
        {
            RuleFor(o => o.StorageDays)
                .GreaterThan(0);
        }
    }
}
