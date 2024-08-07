﻿using Common.Core.Repository;
using LanguageExt;
using Transport.Domain.Models;
using Transport.Persistence;
using Transport.Repository.Repos.Base;

namespace Transport.Repository.Repos
{
    public interface ITransportRepository: IReadOnlyRepositoryBase<Transportt, int>
    {
        //Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids);
        //new Task<Option<Transportt>> GetByIdAsync(int Id);
    }

    internal class TransportRepository: RepositoryBaseDapper<Transportt, int, AppDbContext>, ITransportRepository
    {
        private readonly string TableName;
        public TransportRepository(AppDbContext context): base(context)
        {
            TableName = DbContext.GetTableName<Transportt>();
        }

        public new async Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids)
        {
            return await base.GetByIdsAsync(Ids, TableName);
        }
    }
}
