﻿using Autofac;
using System.Linq;
namespace AspnetCoreBasicArchitecture.Infrastructure.AutoFac
{
    public class RepositoryModule : Module
    {
        private ModuleConfiguration _moduleConfiguration;
        public RepositoryModule(ModuleConfiguration moduleConfiguration)
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
