using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Transport.Persistence
{
    public interface IUnitOfWorkCustom<out TContext> where TContext : DbContext, new()
    {
        //The following Property is going to hold the context object
        TContext Context { get; }

        //Start the database Transaction
        void CreateTransaction();

        //Commit the database Transaction
        void Commit();

        //Rollback the database Transaction
        void Rollback();

        //DbContext Class SaveChanges method
        int Save();
        Task<int> SaveAsync(CancellationToken cancellationToken = default);
        Task RollbackAsync(CancellationToken cancellationToken = default);
        Task CommitAsync(CancellationToken cancellationToken = default);
        Task<int> ExecuteSqlInterpolatedAsync(string Sql);
    }
}
