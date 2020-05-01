using AspnetCoreBasicArchitecture.Services;
using AspnetCoreBasicArchitecture.ViewModel;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace AspnetCoreBasicArchitecture.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductsController(IProductService productService)
        {
            _productService = productService;
        }
        // GET api/products
        [HttpGet]
        public IEnumerable<ProductViewModel> Get() => _productService.Products();

        // GET api/products/1
        [HttpGet("{code}")]
        public ProductViewModel Get(int code) => _productService.GetbyCode(code);

       
    }
}
