using Common.Core.Repository;
using Streets.Persistence.Database;
using Streets.Persistence.Database.Models;

namespace Streets.Application.Repositories
{
    internal class StreetRepository : RepositoryBase<Street, int, AppDbContext>, IStreetRepository
    {
        public StreetRepository(AppDbContext context) : base(context)
        {
        }
    }
}
