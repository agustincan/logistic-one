using Common.Core.Persistence.Repository;
using Transport.Domain.Models;
using Transport.Persistence;

namespace Transport.Repository.Repos
{
    public interface ITransportRepository: IReadOnlyRepositoryBase<Transportt, int>
    {
        //Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids);
        //new Task<Option<Transportt>> GetByIdAsync(int Id);
    }

    internal class TransportRepository: RepositoryBase<Transportt, int, AppDbContext>, ITransportRepository
    {
        //private readonly string TableName;
        public TransportRepository(AppDbContext context): base(context)
        {
            //TableName = DbContext.GetTableName<Transportt>();
        }

        public new async Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids)
        {
            //return await base.GetByIdsAsync(Ids, TableName);
            return await base.GetByIdsAsync(Ids);
        }
    }
}
