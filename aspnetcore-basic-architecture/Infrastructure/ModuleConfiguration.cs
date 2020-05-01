using System.Reflection;
namespace AspnetCoreBasicArchitecture.Infrastructure
{
    public class ModuleConfiguration
    {
        public Assembly ModuleAssembly { get; set; }
        public string Suffix { get; set; }
    }
}
