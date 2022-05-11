using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Purcashing.LoggerService;
using Purchasing.Contracts;
using Purchasing.Entities.RepositoryContexts;
//using Purchasing.Entities.RepositoryContexts;
using Purchasing.Repository;

namespace Purchasing.WebAPI.Extensions
{
    public static class ServiceExtensions
    {
        //depelopmen to postman open to access method POST, GET, DELETE, PUT
        public static void ConfigureCors(this IServiceCollection services) =>
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                    .AllowAnyMethod()
                    .AllowAnyHeader());
            });

        // add IIS configure options deploy to IIS
        public static void ConfigureIISIntegration(this IServiceCollection services) =>
            services.Configure<IISOptions>(options =>
            {

            });

        //create a service once per request
        public static void ConfigureLoggerService(this IServiceCollection services) =>
            services.AddScoped<ILoggerManager, LoggerManager>();

        //configure to db
        public static void ConfigureDbContext(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<AdventureWorks2019Context>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("development"));
            });

        //configure repository
        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

    }//endClassServiceExtensions
}
