using AspnetCoreBasicArchitecture.Repositories;
using AspnetCoreBasicArchitecture.ViewModel;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCoreBasicArchitecture.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;

        public ProductService(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public ProductViewModel GetbyCode(int code)
        {
            var productEntity = _productRepository.GetbyCode(code);
            return new ProductViewModel
            {
                Code = productEntity.Code,
                Name = productEntity.Name,
                Price = productEntity.Price
            };
        }

        public IEnumerable<ProductViewModel> Products()
        {
            return _productRepository.GetAll().Select(x => new ProductViewModel
            {
                Code = x.Code,
                Name = x.Name,
                Price = x.Price
            });
        }

        public double SumOfPrice()
        {
            return _productRepository.GetAll().Sum(x=>x.Price);
        }
    }
}
