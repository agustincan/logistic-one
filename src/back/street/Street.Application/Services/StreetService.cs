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

        public async Task Insert7000()
        {
            await repo.Insert7000();
        }

        public async Task Copy3000()
        {
            await repo.Copy3000();
        }

        public async Task Copy3000Raw()
        {
            await repo.Copy3000Raw();
        }
    }
}
