using Common.Core.Domain;
using Common.Core.Persistence.Repository;
using Dapper;
using LanguageExt;
using Microsoft.EntityFrameworkCore;

namespace Transport.Repository.Repos.Base
{
    public abstract class RepositoryBaseDapperFunctional<TModel, TKey, TDbContext> : RepositoryBaseDapper<TModel, TKey, TDbContext>
        where TKey : struct
        //where T : class
        where TModel : EntityBaseGeneric<TKey>
        where TDbContext: DbContext
    {
        public RepositoryBaseDapperFunctional(TDbContext context) : base(context)
        {
        }
        //public RepositoryBaseDapperFunctional(IDbConnection connection) : base(connection)
        //{
        //}

        //protected async Task<IEnumerable<T>> GetByIdsAsync(TKey[] ids, string TableName)
        //{
        //    var sql = $"SELECT * FROM {TableName} WHERE Id in @Ids";
        //    var pars = new { Ids = ids };
        //    return await connection.QueryAsync<T>(sql, pars);
        //}

        protected new async Task<Option<TModel>> GetByIdAsync(TKey id, string TableName)
        {
            var sql = $"SELECT * FROM {TableName} WHERE Id = @Id";
            var pars = new { Id = id };
            return await connection.QueryFirstAsync<TModel>(sql, pars);
        }

        //protected async Task<IEnumerable<T>> QueryStoreProcedureAsync(string SpName, object pars)
        //{
        //    return await connection.QueryAsync<T>(SpName, pars, commandType: CommandType.StoredProcedure);
        //}
    }
}
