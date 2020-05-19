using AspnetCoreBasicArchitecture.Repositories;
using Autofac;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCoreBasicArchitecture.Infrastructure.Extensions
{

    public static class DatabaseConfigurationServiceExtension
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(configuration.GetConnectionString("ProductConnection")));

        }
        public static void AddConfiguration(this ContainerBuilder builder)
        {

        }
    }
}
