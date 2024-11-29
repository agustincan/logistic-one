using Common.Core.Persistence.Repository;
using LanguageExt;
using Transport.Domain.Models;
using Transport.Persistence;

namespace Transport.Repository.Repos
{
    public interface ITransportRepositoryFunctional: IReadOnlyRepositoryBase<Transportt, int>
    {
        //new Task<Option<IEnumerable<Transportt>>> GetByIdsAsync(int[] Ids);
        new Task<Option<Transportt>> GetByIdAsync(int Id);
    }

    internal class TransportRepositoryFunctional: RepositoryBaseDapper<Transportt, int, AppDbContext>, ITransportRepositoryFunctional
    {
        private readonly string TableName;
        public TransportRepositoryFunctional(AppDbContext context): base(context)
        {
            TableName = context.GetTableName<Transportt>();
        }

        public async Task<Option<Transportt>> GetByIdAsync(int Id)
        {
            return await base.GetByIdAsync(Id, TableName);
        }

        public Task<IEnumerable<Transportt>> GetByIdsAsync(int[] ids)
        {
            throw new NotImplementedException();
        }

        Task<Transportt?> IReadOnlyRepositoryBase<Transportt, int>.GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        //public async Task<Option<IEnumerable<Transportt>>> GetByIdsAsync(int[] Ids)
        //{
        //    return await base.GetByIdsAsync(Ids, TableName);
        //}
    }
}
