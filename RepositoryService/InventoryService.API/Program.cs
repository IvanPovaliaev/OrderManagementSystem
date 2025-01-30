using InventoryService.Application;
using InventoryService.Application.Mappers;
using InventoryService.Application.Products.Queries.GetProductById;
using InventoryService.Infrastructure;
using InventoryService.Infrastructure.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using Serilog;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace InventoryService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) => configuration
                        .ReadFrom.Configuration(context.Configuration)
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("ApplicationName", "InventoryService.API"));

            var connection = builder.Configuration.GetConnectionString("InventoryServiceDatabase");
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connection), ServiceLifetime.Scoped);

            builder.Services.AddAutoMapper(typeof(MappingProfile).Assembly);

            builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblyContaining<GetProductByIdQuery>());

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddControllers()
                            .AddJsonOptions(options =>
                            {
                                options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());
                            }); ;

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(options =>
            {
                var basePath = AppContext.BaseDirectory;

                var xmlPath = Path.Combine(basePath, "InventoryService.API.xml");

                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "InventoryService.API",
                    Description = "Сервис, который хранит информацию о товарах и заказах. Предоставляет REST API для получения информации о товарах, заказах, деталях заказа"
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
