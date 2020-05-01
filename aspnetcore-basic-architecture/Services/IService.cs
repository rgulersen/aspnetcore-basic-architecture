using AspnetCoreBasicArchitecture.Model;
using System.Collections.Generic;

namespace AspnetCoreBasicArchitecture.Services
{
    public interface IService<T> where T : BaseEntity, new()
    {
        IEnumerable<T> GetAll();
    }
}
