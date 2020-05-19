using AspnetCoreBasicArchitecture.Infrastructure.AutoFac;
using Autofac;
using Microsoft.Extensions.Configuration;

namespace AspnetCoreBasicArchitecture.Infrastructure.Extensions
{ 
    public static class AutofacConfigurationServiceExtension
    {
        public static void AddAutofacModuleContainerConfiguration(this ContainerBuilder builder, IConfiguration configuration)
        {
            builder.RegisterModule(new RepositoryModule(configuration.AutoFacModuleConfiguration().RepositoriesSuffix));
            builder.RegisterModule(new RepositoryModule(configuration.AutoFacModuleConfiguration().ServicesSuffix));
            builder.RegisterModule(new RepositoryModule(configuration.AutoFacModuleConfiguration().ValidatorsSuffix));         
        }
    }
}
