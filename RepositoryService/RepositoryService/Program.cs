using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RepositoryService.Application;
using RepositoryService.Application.Mappers;
using RepositoryService.Infrastructure;
using RepositoryService.Infrastructure.Persistence;

namespace RepositoryService.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            var connection = builder.Configuration.GetConnectionString("RepositoryServiceDatabase");
            builder.Services.AddDbContext<DatabaseContext>(options => options.UseNpgsql(connection), ServiceLifetime.Scoped);

            builder.Services.AddAutoMapper(typeof(ProductToProductDTOProfile).Assembly);

            builder.Services.AddApplication();
            builder.Services.AddInfrastructure();

            // Add services to the container.
            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseSwagger();
            app.UseSwaggerUI();

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
