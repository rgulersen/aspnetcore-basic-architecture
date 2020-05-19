using Autofac;
using System.Linq;

namespace AspnetCoreBasicArchitecture.Infrastructure.AutoFac
{
    public class ValidationModule:Module
    {
        private string _suffix;
        public ValidationModule(string suffix)
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
