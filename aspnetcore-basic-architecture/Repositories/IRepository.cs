using System;
using AspnetCoreBasicArchitecture.Model;
using System.Collections.Generic;

namespace AspnetCoreBasicArchitecture.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IEnumerable<T> GetAll();
        T FindById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);
    }
}
