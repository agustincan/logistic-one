using Common.Core.Domain;
using Common.Core.Repository;
using Dapper;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using System.Data;
using Transport.Repository.UowGeneric;

namespace Transport.Repository.Repos.Base
{
    internal abstract class RepositoryBaseDapperUow<T, TKey, TDbContext> : RepositoryBase<T, TKey, TDbContext>
        where TKey : struct
        where T : EntityBaseGeneric<TKey>
        where TDbContext : DbContext, new()
    {
        private readonly IUnitOfWorkGeneric<TDbContext> uow;

        public RepositoryBaseDapperUow(IUnitOfWorkGeneric<TDbContext> uow) : base(uow.Context)
        {
            this.uow = uow;
        }

        protected async Task<IEnumerable<T>> GetByIdsAsync(TKey[] ids, string TableName)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id in @Ids";
            var pars = new { Ids = ids };
            return await connection.QueryAsync<T>(sql, pars);
        }

        protected async Task<Option<T>> GetByIdAsync(TKey id, string TableName)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
            var pars = new { Id = id };
            return await connection.QueryFirstAsync<T>(sql, pars);
        }

        protected async Task<IEnumerable<T>> QueryStoreProcedureAsync(string SpName, object pars)
        {
            return await connection.QueryAsync<T>(SpName, pars, commandType: CommandType.StoredProcedure);
        }
    }
}
