using Gol.Domain.Entities;
using Gol.Domain.Interfaces.Repositories;
using Gol.Infra.Data.Context;

namespace Gol.Infra.Data.Repository
{
    public class TravelRepository : BaseRepository<Travel>, ITravelRepository
    {
        public TravelRepository(ContextDb _context): base (_context)
        {

        }
    }
}
