using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Repositories;
using Gol.Infra.Data.Context;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Gol.Infra.Data.Repository
{
    public class AuthRepository : BaseRepository<AuthUser>, IAuthRepository
    {

        public ContextDb __context;

        public AuthRepository(ContextDb _context) : base(_context)
        {
            __context = _context;
        }

        public bool CheckUser(AuthUser user)
        {
          
                var u = __context.Set<AuthUser>().Where(x => x.User == user.User).FirstOrDefault();
                if (u!=null && u.Id > 0)
                {
                    return true;
                }
                else return false;
           
        }

        public bool Autheticate(AuthUser user)
        {
        
                var u = __context.Set<AuthUser>().Where(x => x.User == user.User && x.Password == user.Password).FirstOrDefault();
                if (u != null && u.Id > 0)
                {
                    return true;
                }
                else return false;
         
        }
    }
}
