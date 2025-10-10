using Bookstore.Application.Interfaces;
using Bookstore.Application.Service;
using Microsoft.Extensions.DependencyInjection;


namespace Bookstore.Application;

public static class ApplicationServiceExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services)
    {
        services.AddScoped<IBookService, BookService>();
        services.AddScoped<IAuthorService, AuthorService>();
        services.AddScoped<IPublisherService, PublisherService>();

        return services;
    }
}