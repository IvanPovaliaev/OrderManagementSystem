using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using RepositoryService.Application;
using RepositoryService.Application.Mappers;
using RepositoryService.Infrastructure;
using RepositoryService.Infrastructure.Persistence;
using Serilog;
using System;
using System.IO;
using System.Text.Json.Serialization;

namespace RepositoryService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Host.UseSerilog((context, configuration) => configuration
                        .ReadFrom.Configuration(context.Configuration)
                        .Enrich.FromLogContext()
                        .Enrich.WithProperty("ApplicationName", "RepositoryService.API"));

            var connection = builder.Configuration.GetConnectionString("RepositoryServiceDatabase");
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connection), ServiceLifetime.Scoped);

            builder.Services.AddAutoMapper(typeof(ProductToProductDTOProfile).Assembly);

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

                var xmlPath = Path.Combine(basePath, "RepositoryService.API.xml");

                options.IncludeXmlComments(xmlPath, includeControllerXmlComments: true);

                options.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "RepositoryService.API",
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
