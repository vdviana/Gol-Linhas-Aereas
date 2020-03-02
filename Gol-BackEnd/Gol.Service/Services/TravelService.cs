using FluentValidation;
using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Repositories;
using Gol.Domain.Interfaces.Services;
using Gol.Service.Validators;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gol.Service.Services
{
    public class TravelService : BaseService<Travel>, ITravelService
    {
        private readonly ITravelRepository _repository;
        public TravelService(ITravelRepository repository) : base(repository)
        {
            _repository = repository;
        }

        

    }
}


