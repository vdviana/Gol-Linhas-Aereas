using Gol.Domain.Entities;

namespace Gol.Domain.Interfaces.Services
{
    public interface IAuthService : IService<AuthUser>
    {

        void Register(AuthUser user);

        AuthUser Authenticate(AuthUser user);
    }
}
