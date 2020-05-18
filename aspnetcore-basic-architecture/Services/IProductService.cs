using AspnetCoreBasicArchitecture.Model;
using AspnetCoreBasicArchitecture.ViewModel;
using System.Collections.Generic;

namespace AspnetCoreBasicArchitecture.Services
{
    public interface IProductService
    {
        IEnumerable<ProductViewModel> Products();
        ProductViewModel GetbyCode(int code);
        double SumOfPrice();
        void Create(ProductViewModel productViewModel);
    }
}
