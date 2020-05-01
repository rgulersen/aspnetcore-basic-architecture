using AspnetCoreBasicArchitecture.Model;
using AspnetCoreBasicArchitecture.Repositories;
using System.Collections.Generic;

namespace AspnetCoreBasicArchitecture.Services
{
    public class Service<T>:IService<T> where T : BaseEntity, new()
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public virtual IEnumerable<T> GetAll()
        {
           return _repository.GetAll();
        }
    }
}
