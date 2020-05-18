using Autofac;
using System.Linq;

namespace AspnetCoreBasicArchitecture.Infrastructure.AutoFac
{
    public class ServiceModule : Module
    {
        private ModuleConfiguration _moduleConfiguration;
        public ServiceModule(ModuleConfiguration moduleConfiguration)
        {
            _moduleConfiguration = moduleConfiguration;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                  .Where(t => t.Name.EndsWith(_moduleConfiguration.Suffix))
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }

    }
}
