using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RepositoryService.Application.Validators;

namespace RepositoryService.Application.Extensions
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
