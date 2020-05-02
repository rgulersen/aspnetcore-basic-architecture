using AspnetCoreBasicArchitecture.Model;
using AspnetCoreBasicArchitecture.ViewModel;
using AutoMapper;

namespace AspnetCoreBasicArchitecture.Infrastructure.AutoMapper
{
    public class ProductProfile:Profile
    {
        public ProductProfile()
        {
            CreateMap<Product, ProductViewModel>();
        }
    }
}
