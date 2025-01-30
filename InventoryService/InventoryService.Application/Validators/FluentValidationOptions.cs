using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace InventoryService.Application.Validators
{
    public class FluentValidationOptions<TOptions> : IValidateOptions<TOptions> where TOptions : class
    {
        private readonly IServiceProvider _serviceProvider;
        private readonly string _name;

        public FluentValidationOptions(IServiceProvider serviceProvider, string name)
        {
            _serviceProvider = serviceProvider;
            _name = name;
        }

        public ValidateOptionsResult Validate(string name, TOptions options)
        {
            if (_name is not null && _name != name)
            {
                return ValidateOptionsResult.Skip;
            }

            ArgumentNullException.ThrowIfNull(options);

            using (var scope = _serviceProvider.CreateScope())
            {
                var validator = scope.ServiceProvider.GetRequiredService<IValidator<TOptions>>();
                var result = validator.Validate(options);
                if (result.IsValid)
                {
                    return ValidateOptionsResult.Success;
                }

                var type = options.GetType().Name;
                var errors = new List<string>();

                foreach (var failure in result.Errors)
                {
                    errors.Add($"Validation failed for {type}.{failure.PropertyName} with error: {failure.ErrorMessage}");
                }

                return ValidateOptionsResult.Fail(errors);
            }
        }
    }
}
