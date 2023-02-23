using Common.Core.Repository;
using LanguageExt;
using Transport.Domain.Models;
using Transport.Persistence;

namespace Transport.Repository.Repos
{
    public interface ITransportRepository: IReadOnlyRepositoryBase<Transportt, int>
    {
        Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids);
        Task<Option<Transportt>> GetByIdAsyncRepo(int Id);
    }

    internal class TransportRepository: RepositoryBaseDapper<Transportt, int, AppDbContext>, ITransportRepository
    {
        public TransportRepository(AppDbContext context): base(context)
        {

        }

        public async Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids)
        {
            return await base.GetByIdsAsync(Ids, "dbo.transports");
        }
        public async Task<Option<Transportt>> GetByIdAsyncRepo(int Id)
        {
            return await base.GetByIdAsync(Id, "dbo.transports");
        }
    }
}
