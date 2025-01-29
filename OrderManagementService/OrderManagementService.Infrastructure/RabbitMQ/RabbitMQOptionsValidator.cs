using FluentValidation;
using OrderManagementService.Application.Models.Options;

namespace OrderManagementService.Infrastructure.RabbitMQ
{
    public class RabbitMQOptionsValidator : AbstractValidator<RabbitMQOptions>
    {
        public RabbitMQOptionsValidator()
        {
            RuleFor(r => r.HostName)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.UserName)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.Password)
                .NotEmpty()
                .NotNull();

            RuleFor(r => r.Port)
                .GreaterThan(0);

            RuleFor(r => r.ExchangeName)
                .NotEmpty()
                .NotNull();

            RuleFor(x => x.CancelOrderRoutingKey).NotEmpty().NotNull();
            RuleFor(x => x.CreateOrderRoutingKey).NotEmpty().NotNull();
            RuleFor(x => x.UpdateOrderItemsRoutingKey).NotEmpty().NotNull();
            RuleFor(x => x.ChangeStatusOrderRoutingKey).NotEmpty().NotNull();
        }
    }
}
