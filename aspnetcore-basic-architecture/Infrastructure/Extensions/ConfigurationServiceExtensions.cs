using AspnetCoreBasicArchitecture.Infrastructure.ConfiggurationModels;
using AspnetCoreBasicArchitecture.Infrastructure.ConfigurationModels;
using Microsoft.Extensions.Configuration;

namespace AspnetCoreBasicArchitecture.Infrastructure.Extensions
{
    public static class ConfigurationExtension
    {
        public static AutofacModuleConfiguration AutoFacModuleConfiguration(this IConfiguration configuration)
        {
            return new AutofacModuleConfiguration
            {
                RepositoriesSuffix = configuration["AutoFacModuleConfiguration:Repositories:Suffix"],
                ServicesSuffix = configuration["AutoFacModuleConfiguration:Services:Suffix"],
                ValidatorsSuffix = configuration["AutoFacModuleConfiguration:Validator:Suffix"],

            };
        }

        public static JwtTokenConfiguration JwtTokenConfiguration(this IConfiguration configuration)
        {
            return new JwtTokenConfiguration
            {
                ValidAudience = configuration["JwtConfiguration:Token:ValidAudience"],
                ValidIssuer = configuration["JwtConfiguration:Token:ValidIssuer"],
                IssuerSigningKey = configuration["JwtConfiguration:Token:IssuerSigningKey"]
            };
        }

        public static SwaggerConfiguration SwaggerConfiguration(this IConfiguration configuration)
        {
            return new SwaggerConfiguration
            {
                Version = configuration["SwaggerConfiguration:Version"],
                Title = configuration["SwaggerConfiguration:Title"],
                LicenseName = configuration["SwaggerConfiguration:LicenseName"],
                LicenseUri = configuration["SwaggerConfiguration:LicenseUri"],
                SwaggerEndpointUrl = configuration["SwaggerConfiguration:SwaggerEndpoint:Url"],
                SwaggerEndpointName = configuration["SwaggerConfiguration:SwaggerEndpoint:Name"]
            };
        }
    }
}
