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
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using FluentValidation.AspNetCore;
using AspnetCoreBasicArchitecture.Infrastructure.Filters;
using Microsoft.OpenApi.Models;

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
            services.AddMvc(o => o.Filters.Add(new ValidationFilter()))
                .AddFluentValidation(v =>
                {
                    v.RegisterValidatorsFromAssemblyContaining<ValidationModule>();
                    v.RunDefaultMvcValidationAfterFluentValidationExecutes = false;
                })
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connectionSetring = Configuration.GetConnectionString("ProductConnection");
            services.AddDbContext<DatabaseContext>(options => options.UseSqlServer(Configuration.GetConnectionString("ProductConnection")));

            services.AddIdentity<IdentityUser, IdentityRole>(options =>
                {
                    options.Password.RequireDigit = true;
                    options.Password.RequireUppercase = true;
                    options.Password.RequiredLength = 8;
                }).AddEntityFrameworkStores<DatabaseContext>().AddDefaultTokenProviders();

            services.AddAuthentication(authentication =>
            {
                authentication.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authentication.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = "demo",
                    ValidIssuer = "demo",
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("this is my custom Secret key for authnetication")),
                    ValidateIssuerSigningKey = true
                };

            });
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Product API",
                    License = new OpenApiLicense
                    {
                        Name = "MIT",
                        Url = new Uri("https://opensource.org/licenses/MIT")
                    }
                });
            });

        }

        public void ConfigureContainer(ContainerBuilder builder)
        {
            builder.RegisterModule(new RepositoryModule(new ModuleConfiguration
            {
                Suffix = Configuration["AutoFacModuleConfiguration:Repositories:Suffix"]
            }));
            builder.RegisterModule(new ServiceModule(new ModuleConfiguration
            {
                Suffix = Configuration["AutoFacModuleConfiguration:Services:Suffix"]
            }));
            builder.RegisterModule(new ValidationModule(new ModuleConfiguration
            {
                Suffix = Configuration["AutoFacModuleConfiguration:Validator:Suffix"]
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
            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Product API V1");
            });
        }


    }

}
