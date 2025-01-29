using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using OrderManagementService.Application.Validators;

namespace OrderManagementService.Application.Extensions
{
    public static class OptionsBuilderExtensions
    {
        public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> builder) where TOptions : class
        {
            builder.Services.AddSingleton<IValidateOptions<TOptions>>(
                serviceProvider => new FluentValidationOptions<TOptions>(serviceProvider, builder.Name));

            return builder;
        }
    }
}
