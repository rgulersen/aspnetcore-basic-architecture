using Autofac;
using System.Linq;

namespace AspnetCoreBasicArchitecture.Infrastructure.AutoFac
{
    public class ServiceModule : Module
    {
        private readonly string _suffix;
        public ServiceModule(string suffix)
        {
            _suffix = suffix;
        }

        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(ThisAssembly)
                  .Where(t => t.Name.EndsWith(_suffix))
                  .AsImplementedInterfaces()
                  .InstancePerLifetimeScope();
        }

    }
}
