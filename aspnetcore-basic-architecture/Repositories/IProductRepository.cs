using AspnetCoreBasicArchitecture.Model;

namespace AspnetCoreBasicArchitecture.Repositories
{
    public interface  IProductRepository:IRepository<Product>
    {
        Product GetbyCode(int code);
    }
}
