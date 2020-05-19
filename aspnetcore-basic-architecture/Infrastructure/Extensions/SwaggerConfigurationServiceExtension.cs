using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;
using System;

namespace AspnetCoreBasicArchitecture.Infrastructure.Extensions
{
    public static class SwaggerConfigurationServiceExtension
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(
                    configuration.SwaggerConfiguration().Version,
                    configuration.SwaggerConfiguration().ConvertOpenApiInfo()
                    );
            });
        }

        public static void UseSwaggerUIConfiguration(this IApplicationBuilder app, IConfiguration configuration)
        {
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint(
                    configuration.SwaggerConfiguration().SwaggerEndpointUrl,
                    configuration.SwaggerConfiguration().SwaggerEndpointName
                    );
            });
        }
    }



}
