using FluentValidation;

namespace OrderManagementService.Infrastructure.InventoryService
{
    public class InventoryServiceOptionsValidator : AbstractValidator<InventoryServiceOptions>
    {
        public InventoryServiceOptionsValidator()
        {
            RuleFor(r => r.Url)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.Timeout)
                .GreaterThan(0);
        }
    }
}
