﻿using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using OrderManagementService.Application.Interfaces;
using OrderManagementService.Application.Services;
using OrderManagementService.Application.Validators.DTOs;

namespace OrderManagementService.Application
{
    public static class DependencyInjection
    {
        /// <summary>
        /// Extension method to add application services to the dependency injection container
        /// </summary>
        /// <param name="services">Current service collection</param>
        /// <returns>Current service collection with new Application services</returns>
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddValidatorsFromAssemblyContaining<ChangeOrderStatusDTOValidator>();
            services.AddTransient<IOrdersService, OrderService>();

            return services;
        }
    }
}
