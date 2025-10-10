using AutoMapper;
using Bookstore.Application;
using Bookstore.Application.Common;
using Bookstore.Infrastructure;
using FluentValidation;
using Serilog;
using Bookstore.Api.Middleware;

namespace Bookstore.Api;

public class Program
{
    public static void Main(string[] args)
    {
        Log.Logger = new LoggerConfiguration()
            .ReadFrom.Configuration(new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build())
            .CreateLogger();

        try
        {

            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddCors(options =>
            {
                options.AddPolicy("AllowReactApp",
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:5173")
                               .AllowAnyHeader()
                               .AllowAnyMethod();
                    });
            });

            builder.Host.UseSerilog();

            builder.Services.AddApplicationServices();
            builder.Services.AddInfrastructureServices(builder.Configuration);

            using var serviceProvider = builder.Services.BuildServiceProvider(); //Fensi registracija za mapper koju ne razumem za sada
            var loggerFactory = serviceProvider.GetRequiredService<ILoggerFactory>();
            var configExpression = new MapperConfigurationExpression();
            configExpression.AddMaps(typeof(BookMappings).Assembly);
            var mapperConfig = new MapperConfiguration(configExpression, loggerFactory);
            IMapper mapper = mapperConfig.CreateMapper();
            builder.Services.AddSingleton(mapper);

            builder.Services.AddTransient<ExceptionHandlingMiddleware>();

            builder.Services.AddValidatorsFromAssemblyContaining<BookMappings>(); //FluentValidation

            builder.Services.AddControllers();

            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            app.UseMiddleware<ExceptionHandlingMiddleware>();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors("AllowReactApp");

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
        catch (Exception ex)
        {
            Log.Fatal(ex, "ERROR: Fatal error");
        }
        finally
        {
            Log.CloseAndFlush();
        }
    }
}
