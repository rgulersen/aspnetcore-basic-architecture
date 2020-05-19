using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCoreBasicArchitecture.Infrastructure.Extensions
{
    public static class AutoMapperConfigurationServiceExtension
    {
        public static void AddAutoMapperConfiguration(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
        }
    }
}
