using AspnetCoreBasicArchitecture.Repositories;
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
    }
}
