using Autofac;
using System.Linq;
using System.Reflection;
using Module = Autofac.Module;

namespace AspnetCoreBasicArchitecture.Infrastructure
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
            builder.RegisterAssemblyTypes(_moduleConfiguration.ModuleAssembly)
                  .Where(t => t.Name.EndsWith(_moduleConfiguration.Suffix))
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }

    }
}
