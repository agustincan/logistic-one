using System.ComponentModel.DataAnnotations;
using LanguageExt;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace Transport.Repository.UowGeneric
{
    //Generic UnitOfWork Class. 
    //While Creating an Instance of the UnitOfWork object, we need to specify the actual type for the TContext Generic Type
    //In our example, TContext is going to be EmployeeDBContext
    //new() constraint will make sure that this type is going to be a non-abstract type with a parameterless constructor
    public class UnitOfWorkGeneric<TDbContext> : IUnitOfWorkGeneric<TDbContext>, IDisposable 
        where TDbContext : DbContext, new()
    {
        private bool _disposed;
        private string _errorMessage = string.Empty;

        //The following Object is going to hold the Transaction Object
        private IDbContextTransaction? _objTran;
        private readonly TDbContext context;

        //Using the Constructor we are initializing the Context Property which is declared in the IUnitOfWork Interface
        //This is nothing but we are storing the DBContext (EmployeeDBContext) object in Context Property
        public UnitOfWorkGeneric(TDbContext context)
        {
            this.context = context;
        }

        //The Dispose() method is used to free unmanaged resources like files, 
        //database connections etc. at any time.
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        public async Task DisposeAsync()
        {
            await DisposeAsync(true);
            GC.SuppressFinalize(this);
        }

        //The Context property will return the DBContext object i.e. (EmployeeDBContext) object
        //This Property is declared inside the Parent Interface and Initialized through the Constructor
        public TDbContext Context => context;

        //The CreateTransaction() method will create a database Transaction so that we can do database operations
        //by applying do everything and do nothing principle
        public void CreateTransaction()
        {
            //It will Begin the transaction on the underlying store connection
            _objTran = Context.Database.BeginTransaction();
        }

        public async Task CreateTransactionAsync()
        {
            //It will Begin the transaction on the underlying store connection
            _objTran = await Context.Database.BeginTransactionAsync();
        }

        //If all the Transactions are completed successfully then we need to call this Commit() 
        //method to Save the changes permanently in the database
        public void Commit()
        {
            //Commits the underlying store transaction
            _objTran?.Commit();
        }

        public async Task CommitAsync(CancellationToken cancellationToken = default)
        {
            //Commits the underlying store transaction
            if (_objTran is not null)
                await _objTran.CommitAsync(cancellationToken);
        }

        //If at least one of the Transaction is Failed then we need to call this Rollback() 
        //method to Rollback the database changes to its previous state
        public void Rollback()
        {
            //Rolls back the underlying store transaction
            _objTran?.Rollback();
            //The Dispose Method will clean up this transaction object and ensures Entity Framework
            //is no longer using that transaction.
            _objTran?.Dispose();
        }

        public async Task RollbackAsync(CancellationToken cancellationToken = default)
        {
            //Rolls back the underlying store transaction
            if(_objTran is not null)
            {
                await _objTran.RollbackAsync(cancellationToken);
                //The Dispose Method will clean up this transaction object and ensures Entity Framework
                //is no longer using that transaction.
                await _objTran.DisposeAsync();
            }
        }

        private void CheckValidations()
        {
            var validationResults = Context.ChangeTracker
                     .Entries<IValidatableObject>()
                     .SelectMany(e => e.Entity.Validate(null!))
                     .Where(r => r != ValidationResult.Success);

            if (validationResults.Any())
            {
                foreach (var validationError in validationResults)
                {
                    _errorMessage += $"Error: {validationError} {Environment.NewLine}";
                    foreach (var validationMember in validationError.MemberNames)
                    {
                        //_errorMessage += $"Property: {validationError.PropertyName} Error: {validationError} {Environment.NewLine}";

                    }
                }
                throw new Exception(_errorMessage);
            }
        }

        //The Save() Method Implement DbContext Class SaveChanges method 
        //So whenever we do a transaction we need to call this Save() method 
        //so that it will make the changes in the database permanently
        public int Save()
        {
            CheckValidations();
            //Calling DbContext Class SaveChanges method 
            return Context.SaveChanges();
        }

        public async Task<int> ExecuteSqlInterpolatedAsync(string Sql)
        {
            return await Context.Database.ExecuteSqlInterpolatedAsync($"{Sql}");
        }

        public Task<int> SaveAsync(CancellationToken cancellationToken = default)
        {
            CheckValidations();
            //Calling DbContext Class SaveChanges method 
            return Context.SaveChangesAsync(cancellationToken);
        }

        //Disposing of the Context Object
        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    Context.Dispose();
            _disposed = true;
        }

        protected virtual async Task DisposeAsync(bool disposing)
        {
            if (!_disposed)
                if (disposing)
                    await Context.DisposeAsync();
            _disposed = true;
        }
    }
}
