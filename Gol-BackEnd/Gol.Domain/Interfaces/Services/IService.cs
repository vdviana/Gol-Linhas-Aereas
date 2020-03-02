using FluentValidation;
using System.Collections.Generic;
using Gol.Domain.Entities;

namespace Gol.Domain.Interfaces.Services
{
    public interface IService<T> where T : BaseEntity
    {
        T Insert<V>(T obj) where V : AbstractValidator<T>;

        T Update<V>(T obj) where V : AbstractValidator<T>;

        int Delete(int id);

        T GetById(int id);

        IList<T> GetAll();
    }
}
