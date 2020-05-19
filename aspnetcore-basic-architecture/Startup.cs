using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Autofac;
using AspnetCoreBasicArchitecture.Infrastructure.Extensions;

namespace AspnetCoreBasicArchitecture
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapperConfiguration();
            services.AddFluentValidationConfiguration();
            services.AddDatabaseConfiguration(Configuration);
            services.AddIdentityConfiguration();
            services.AddJwtConfiguration(Configuration);
            services.AddSwaggerConfiguration(Configuration);
        }
        public void ConfigureContainer(ContainerBuilder builder) => builder.AddAutofacModuleContainerConfiguration(Configuration);

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwaggerUIConfiguration(Configuration);
        }
    }
}
