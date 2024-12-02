namespace Streets.Persistence.Database
{
    public interface IUnitOfWork
    {
        //AppDbContext Context { get; }

        Task<int> SaveAsync(CancellationToken cancellatinToken = default);
    }

    internal class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext context;

        public UnitOfWork(AppDbContext context)
        {
            this.context = context;
        }

        //public DbSet<T> SetEntity<T>()
        //{
        //    return context.Set<T>();
        //}

        public async Task<int> SaveAsync(CancellationToken cancellatinToken = default)
        {
            return await context.SaveChangesAsync(cancellatinToken);
        }
    }
}
