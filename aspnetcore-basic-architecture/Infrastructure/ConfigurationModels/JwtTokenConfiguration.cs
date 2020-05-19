using System.Text;

namespace AspnetCoreBasicArchitecture.Infrastructure.ConfigurationModels
{
    public class JwtTokenConfiguration
    {
        public string ValidAudience { get; set; }
        public string ValidIssuer { get; set; }
        public string IssuerSigningKey { get; set; }

        public byte[] ConvertBytes() => Encoding.UTF8.GetBytes("Your Secret Key !");
    }
}
