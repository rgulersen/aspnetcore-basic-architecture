using System;
using AspnetCoreBasicArchitecture.Model;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace AspnetCoreBasicArchitecture.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        protected readonly DatabaseContext _db;

        private DbSet<T> _entities;

        public Repository(DatabaseContext context)
        {
            _db = context;
            _entities = context.Set<T>();
        }
        public void Add(T entity)
        {
            _db.Add(entity);
            _db.SaveChanges();
        }

        public void Delete(Guid id)
        {
            var entity = _entities.SingleOrDefault(x => x.Id == id);
            _db.Remove(entity);
            _db.SaveChanges();
        }

        public T FindById(Guid id)
        {
            return _entities.SingleOrDefault(x => x.Id == id);
        }

        public IEnumerable<T> GetAll()
        {
            return _entities.AsEnumerable();
        }

        public void Update(T entity)
        {
            _db.Update(entity);
            _db.SaveChanges();
        }
    }
}
