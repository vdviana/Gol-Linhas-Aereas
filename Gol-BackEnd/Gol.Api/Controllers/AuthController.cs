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
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _AuthService;
        public AuthController(IAuthService authService)
        {
            _AuthService = authService;
        }

        [HttpPost]
        public string  Register([FromBody] AuthUser user)
        {
            try
            {
                _AuthService.Register(user);
                return "Usuário registrado";
            }
            catch (Exception ex) 
            {
                return string.Format("ocorreu um erro ao registrar o usuário - {0}", ex.Message);
            }
        }     

        [HttpPost]
        public AuthUser Authenticate([FromBody] AuthUser obj)
        {
            return _AuthService.Authenticate(obj);
        }        
    }
}
