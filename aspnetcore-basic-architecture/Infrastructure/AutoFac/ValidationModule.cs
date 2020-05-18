using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AspnetCoreBasicArchitecture.Infrastructure.AutoFac
{
    public class ValidationModule:Module
    {
        private ModuleConfiguration _moduleConfiguration;
        public ValidationModule(ModuleConfiguration moduleConfiguration)
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
