using Microsoft.EntityFrameworkCore;

namespace Transport.Repository.UowGeneric
{
    public interface IUnitOfWorkGeneric<TDbContext> 
        where TDbContext : DbContext, new()
    {
        //The following Property is going to hold the context object
        TDbContext Context { get; }

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
