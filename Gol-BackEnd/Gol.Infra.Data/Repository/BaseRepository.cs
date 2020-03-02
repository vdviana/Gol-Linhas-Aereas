using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Repositories;
using Gol.Infra.Data.Context;

namespace Gol.Infra.Data.Repository
{
    public class BaseRepository<T> : IRepository<T> where T : BaseEntity
    {
        //public readonly MySqlContext _context;

        public readonly ContextDb _context;

        public BaseRepository(ContextDb context)
        {
            _context = context;
        }

        public dynamic GetContext() 
        {
            return _context;
        }
               
        public void Insert(T obj)
        {
            _context.Set<T>().Add(obj);
            _context.SaveChanges();
        }

        public int Remove(int id)
        {
            if (Select(id) != null)
            {
                _context.Set<T>().Remove(Select(id));
                return _context.SaveChanges();
            }
            return 0;
        }

        public T Select(int id)
        {
            return _context.Set<T>().Find(id);
        }

        public IList<T> SelectAll()
        {
            return _context.Set<T>().ToList();
        }

        public void Update(T obj)
        {
            _context.Entry(obj).State = EntityState.Modified;
            _context.SaveChanges();
        }
    }
}
