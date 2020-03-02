using Gol.Domain.Entities;

namespace Gol.Domain.Interfaces.Repositories
{
    public interface IAuthRepository : IRepository<AuthUser>
    {
        bool CheckUser(AuthUser user);
        bool Autheticate(AuthUser user);
    }
}
