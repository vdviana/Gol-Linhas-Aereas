using FluentValidation;
using System;
using System.Collections.Generic;
using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Repositories;
using Gol.Domain.Interfaces.Services;

namespace Gol.Service.Services
{
    public class BaseService<T> : IService<T> where T : BaseEntity
    {

        private readonly IRepository<T> _repository;
        
            
        public BaseService(IRepository<T> repository)
        {
            _repository = repository;
        
        }


        public T Insert<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Insert(obj);
            return obj;
        }

        public T Update<V>(T obj) where V : AbstractValidator<T>
        {
            Validate(obj, Activator.CreateInstance<V>());

            _repository.Update(obj);
            return obj;
        }

        public int Delete(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

           return _repository.Remove(id);
        }






        public IList<T> GetAll() => _repository.SelectAll();

        public T GetById(int id)
        {
            if (id == 0)
                throw new ArgumentException("The id can't be zero.");

            return _repository.Select(id);
        }

        private void Validate(T obj, AbstractValidator<T> validator)
        {
            if (obj == null)
                throw new Exception("Registros não detectados!");

            validator.ValidateAndThrow(obj);
        }
    }
}
