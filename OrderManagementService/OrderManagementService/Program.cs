using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
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

            builder.Services.AddControllers();

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
