using System;
using AspnetCoreBasicArchitecture.Model;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AspnetCoreBasicArchitecture.Repositories
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IEnumerable<T> GetAll();
        T FindById(Guid id);
        void Add(T entity);
        void Update(T entity);
        void Delete(Guid id);

        #region async 
        Task AddAsync(T entity);
        Task<IEnumerable<T>> GetAllAsync();
        Task  UpdateAsync(T entity);
        Task DeleteAsync(Guid id);
        Task<T> FindByIdAsync(Guid id);

        #endregion

    }
}
