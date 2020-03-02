using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Services;
using Gol.Service.Validators;
using System;


namespace Gol.Application.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TravelController : ControllerBase
    {
        private readonly ITravelService _userService;

        public TravelController(ITravelService userService)
        {
            _userService = userService;
        }
        [HttpPost]
        public IActionResult PostArquivot()
        {
            return Ok("");

        }

        [HttpGet]
        public IEnumerable<Travel> GetAll()
        {


            var retorno = _userService.GetAll() ?? new List<Travel>();
            return retorno;
        }

        [HttpGet("{id}")]
        public Travel GetById(int id)
        {
            return _userService.GetById(id) ?? new Travel();
        }

        [HttpPost]
        public Travel Insert([FromBody] Travel obj)
        {
            return _userService.Insert<TravelValidator>(obj)?? new Travel();
        }

        [HttpPut]
        public Travel Update([FromBody] Travel obj)
        {
            return _userService.Update<TravelValidator>(obj) ?? new Travel();
        }

        [HttpDelete("{id}")]
        public int Delete(int id)
        {
         
         return   _userService.Delete(id);

        }
    }
}
