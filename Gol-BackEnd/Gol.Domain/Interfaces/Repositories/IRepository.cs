using System.Collections.Generic;
using Gol.Domain.Entities;

namespace Gol.Domain.Interfaces.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        dynamic GetContext();
        void Insert(T obj);

        void Update(T obj);

        int Remove(int id);

        T Select(int id);

        IList<T> SelectAll();
    }
}
