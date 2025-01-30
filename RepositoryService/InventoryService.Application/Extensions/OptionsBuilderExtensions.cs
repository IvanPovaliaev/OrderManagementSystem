using InventoryService.Application.Validators;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

namespace InventoryService.Application.Extensions
{
    public static class OptionsBuilderExtensions
    {
        /// <summary>
        /// Adds FluentValidation-based validation for the specified options type.
        /// </summary>
        /// <typeparam name="TOptions">The type of options being validated.</typeparam>
        /// <param name="builder">The options builder to configure.</param>
        /// <returns>The configured options builder.</returns>
        public static OptionsBuilder<TOptions> ValidateFluentValidation<TOptions>(this OptionsBuilder<TOptions> builder) where TOptions : class
        {
            builder.Services.AddSingleton<IValidateOptions<TOptions>>(
                serviceProvider => new FluentValidationOptions<TOptions>(serviceProvider, builder.Name));

            return builder;
        }
    }
}
