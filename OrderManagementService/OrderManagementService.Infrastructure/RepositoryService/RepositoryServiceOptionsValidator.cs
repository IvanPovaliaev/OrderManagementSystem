using FluentValidation;

namespace OrderManagementService.Infrastructure.RepositoryService
{
    public class RepositoryServiceOptionsValidator : AbstractValidator<RepositoryServiceOptions>
    {
        public RepositoryServiceOptionsValidator()
        {
            RuleFor(r => r.Url)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.Timeout)
                .GreaterThan(0);
        }
    }
}
