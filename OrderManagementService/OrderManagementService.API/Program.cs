using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using OrderManagementService.Application;
using OrderManagementService.Application.Extensions;
using OrderManagementService.Application.Models.Mappers;
using OrderManagementService.Application.Models.Options;
using OrderManagementService.Infrastructure;
using Serilog;
using SharpGrip.FluentValidation.AutoValidation.Mvc.Extensions;
using System;
using System.IO;

namespace OrderManagementService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) => configuration
                        .ReadFrom.Configuration(context.Configuration)
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("ApplicationName", "OrderManagementService"));

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            var ordersConfiguration = builder.Configuration.GetSection("OrdersOptions");

            builder.Services.AddFluentValidationAutoValidation();

            builder.Services.AddOptions<OrdersOptions>()
                            .Bind(ordersConfiguration)
                            .ValidateFluentValidation()
                            .ValidateOnStart();

            builder.Services.AddControllers();

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "OrderManagementService.xml");

                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "OrderManagementService",
                    Description = "Сервис, который предоставляет REST API для управления заказами."
                });
            });

            var app = builder.Build();

            app.UseSerilogRequestLogging();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
