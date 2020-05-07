using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspnetCoreBasicArchitecture.Repositories;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AspnetCoreBasicArchitecture.Services;
using Autofac.Extensions.DependencyInjection;
using Autofac;
using AspnetCoreBasicArchitecture.Infrastructure.AutoFac;
using System.Reflection;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace AspnetCoreBasicArchitecture
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        //// This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionSetring = Configuration.GetConnectionString("ProductConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 8;
                }).AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            var assemblyName = Assembly.GetExecutingAssembly().GetName().Name;
            var assembly = Assembly.Load(assemblyName);

            builder.RegisterModule(new RepositoryModule(new ModuleConfiguration
            {
                ModuleAssembly = assembly,
                Suffix = Configuration["AutoFacModuleConfiguration:Repositories:Suffix"]
            }));
            builder.RegisterModule(new ServiceModule(new ModuleConfiguration
            {
                ModuleAssembly = assembly,
                Suffix = Configuration["AutoFacModuleConfiguration:Services:Suffix"]
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
