using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using Bookstore.Infrastructure.Data;
using Bookstore.Domain.Interfaces;

namespace Bookstore.Infrastructure;

public static class InfrastructureServiceExtensions
{
    public static IServiceCollection AddInfrastructureServices(
        this IServiceCollection services,
        IConfiguration configuration) //Ne razumem ovaj poziv
    {

        services.AddDbContext<BookstoreDbContext>(options =>
            options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")).UseSnakeCaseNamingConvention());

        services.AddScoped<IUnitOfWork, UnitOfWork>();

        return services;
    }
}

