using System.Collections.Generic;

namespace Gol.Domain.Entities
{
    public class AuthUser : BaseEntity
    {
        public string User { get; set; }
        public string Password { get; set; }
    }

}