using AspnetCoreBasicArchitecture.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCoreBasicArchitecture.Infrastructure.Extensions
{
    public static class IdentityConfigurationServiceExtension
    {
        public static void AddIdentityConfiguration(this IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.Password.RequireDigit = true;
                options.Password.RequireUppercase = true;
                options.Password.RequiredLength = 8;
            }).AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

        }
    }
}
