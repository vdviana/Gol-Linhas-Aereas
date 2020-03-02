using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Repositories;
using Gol.Domain.Interfaces.Services;
using Microsoft.EntityFrameworkCore;
using System;

namespace Gol.Service.Services
{
    public class AuthService : BaseService<AuthUser>, IAuthService
    {
        private readonly IAuthRepository _repository;
        public AuthService(IAuthRepository repository) : base(repository)
        {
            _repository = repository;
        }

        public AuthUser Authenticate(AuthUser user)
        {

            if (_repository.Autheticate(user))
                return user;
            else
                throw new Exception("Invalid user and/or password");
                
        }

        public void Register(AuthUser user)
        {
            if (_repository.CheckUser(user))
            { throw new Exception("This user is already used"); }

            try
            {
                _repository.Insert(user);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
