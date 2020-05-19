using Microsoft.OpenApi.Models;
using System;

namespace AspnetCoreBasicArchitecture.Infrastructure.ConfigurationModels
{
    public class SwaggerConfiguration
    {
        public string Version { get; set; }
        public string Title { get; set; }
        public string LicenseName { get; set; }
        public string LicenseUri { get; set; }
        public string SwaggerEndpointUrl { get; set; }
        public string SwaggerEndpointName { get; set; }

        public OpenApiInfo ConvertOpenApiInfo()
        {
            return new OpenApiInfo
            {
                Title = Title,
                License = new OpenApiLicense
                {
                    Name = LicenseName,
                    Url = new Uri(LicenseUri)
                }
            };
        }
    }
}
