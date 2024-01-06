using Streets.Application.Repositories;
using Streets.Persistence.Database.Models;

namespace Streets.Application.Services
{
    internal class StreetService: IStreetService
    {
        private readonly IStreetRepository repo;

        public StreetService(IStreetRepository repo)
        {
            this.repo = repo;
        }

        public async Task<IEnumerable<Street>> GetByIdsAsync(int[] Ids) 
        {
            return await repo.GetByIdsAsync(Ids);
        }
    }
}
