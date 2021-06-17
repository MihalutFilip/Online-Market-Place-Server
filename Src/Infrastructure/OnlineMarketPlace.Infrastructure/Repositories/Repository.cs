using Microsoft.EntityFrameworkCore;
using OnlineMarketPlace.Domain;
using OnlineMarketPlace.Infrastructure.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OnlineMarketPlace.Infrastructure.Repositories
{
    public class Repository<T> : IRepository<T> where T : Entity
    {
        protected readonly DbSet<T> _table;
        protected readonly MarketPlaceContext _context;

        public Repository(MarketPlaceContext context)
        {
            _context = context;
            _table = _context.Set<T>();
        }

        public virtual IEnumerable<T> GetAll()
        {
            return _table.AsEnumerable();
        }
        public virtual T GetById(int id)
        {
            return _table.SingleOrDefault(s => s.Id == id);
        }
        public T Insert(T entity)
        {
            if (entity == null) throw new ArgumentNullException("Null entity");

            _table.Add(entity);
            _context.SaveChanges();

            return entity;
        }
        public T Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("Null entity");

            _table.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();

            return entity;
        }
        public void Delete(int id)
        {
            if (id == null) throw new ArgumentNullException("Null id");

            T entity = _table.SingleOrDefault(s => s.Id == id);
            _table.Remove(entity);
            _context.SaveChanges();
        }
    }
}
