using AspnetCoreBasicArchitecture.Infrastructure.AutoFac;
using AspnetCoreBasicArchitecture.Infrastructure.Filters;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;

namespace AspnetCoreBasicArchitecture.Infrastructure.Extensions
{
    public static class FluentValidationConfigurationServiceExtension
    {
        public static void AddFluentValidationConfiguration(this IServiceCollection services)
        {
            services.AddMvc(o => o.Filters.Add(new ValidationFilter()))
              .AddFluentValidation(v =>
              {
                  v.RegisterValidatorsFromAssemblyContaining<ValidationModule>();
                  v.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
              })
              .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
        }
    }
}
