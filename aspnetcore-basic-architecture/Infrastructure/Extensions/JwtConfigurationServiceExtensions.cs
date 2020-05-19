using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace AspnetCoreBasicArchitecture.Infrastructure.Extensions
{
    public static class JwtConfigurationServiceExtension
    {
        public static void AddJwtConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
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
                    ValidAudience = configuration.JwtTokenConfiguration().ValidAudience,
                    ValidIssuer = configuration.JwtTokenConfiguration().ValidIssuer,
                    RequireExpirationTime = true,
                    IssuerSigningKey = new SymmetricSecurityKey(configuration.JwtTokenConfiguration().ConvertBytes()),
                    ValidateIssuerSigningKey = true
                };
            });

        }
    }
}
