using Common.Core.Repository;
using LanguageExt;
using Transport.Domain.Models;
using Transport.Persistence;
using Transport.Repository.Repos.Base;

namespace Transport.Repository.Repos
{
    public interface ITransportRepositoryFunctional: IReadOnlyRepositoryBase<Transportt, int>
    {
        //Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids);
        //new Task<Option<Transportt>> GetByIdAsync(int Id);
    }

    internal class TransportRepositoryFunctional: RepositoryBaseDapper<Transportt, int, AppDbContext>, ITransportRepositoryFunctional
    {
        private readonly string TableName;
        public TransportRepositoryFunctional(AppDbContext context): base(context)
        {
            TableName = DbContext.GetTableName<Transportt>();
        }

        public new async Task<Option<Transportt>> GetByIdAsync(int Id)
        {
            return await base.GetByIdAsync(Id, TableName);
        }

        //public new async Task<Option<IEnumerable<Transportt>>> GetByIdsAsync(int[] Ids)
        //{
        //    return await base.GetByIdsAsync(Ids, TableName);
        //}
    }
}
