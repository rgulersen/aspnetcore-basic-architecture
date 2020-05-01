using System.Linq;
using AspnetCoreBasicArchitecture.Model;

namespace AspnetCoreBasicArchitecture.Repositories
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        public ProductRepository(DatabaseContext context) : base(context)
        {
        }

        public Product GetbyCode(int code)
        {
            return GetAll().FirstOrDefault(x => x.Code == code);
        }
    }
}
