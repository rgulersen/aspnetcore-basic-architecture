using AspnetCoreBasicArchitecture.Model;
using AspnetCoreBasicArchitecture.Repositories;
using AspnetCoreBasicArchitecture.ViewModel;
using AutoMapper;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCoreBasicArchitecture.Services
{
    public class ProductService : IProductService
    {
        private IProductRepository _productRepository;
        private IMapper _mapper;

        public ProductService(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }

        public ProductViewModel GetbyCode(int code)
        {
            var productEntity = _productRepository.GetbyCode(code);
           return  _mapper.Map<Product, ProductViewModel>(productEntity);
        }

        public IEnumerable<ProductViewModel> Products()
        {
            var products = _productRepository.GetAll();
            return  _mapper.Map<IEnumerable<Product>, IEnumerable<ProductViewModel>>(products);
        }

        public double SumOfPrice()
        {
            return _productRepository.GetAll().Sum(x => x.Price);
        }

        public void Create(ProductViewModel productViewModel)
        {
            _productRepository.Add(new Product
            {
                Code=productViewModel.Code,Name=productViewModel.Name,Price=productViewModel.Price
            });
        }
    }
}
