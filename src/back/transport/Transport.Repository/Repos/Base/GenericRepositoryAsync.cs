using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;
using Transport.Repository.UowGeneric;

namespace Transport.Repository.Repos.Base
{
    public abstract class GenericRepositoryAsync<T, TDbContext> : IGenericRepositoryAsync<T, TDbContext>, IAsyncDisposable
        where T : class
        where TDbContext : DbContext, new()
    {
        private DbSet<T> _entities;
        private string _errorMessage = string.Empty;
        private bool _isDisposed;
        private readonly IUnitOfWorkGeneric<TDbContext> unitOfWork;

        //While Creating an Instance of GenericRepository, we need to pass the UnitOfWork instance
        //That UnitOfWork instance contains the Context Object that our GenericRepository is going to use
        public GenericRepositoryAsync(IUnitOfWorkGeneric<TDbContext> unitOfWork)
        {
            _entities = unitOfWork.Context.Set<T>();
            this.unitOfWork = unitOfWork;
        }
        //If you don't want to use Unit of Work, then use the following Constructor 
        //which takes the context Object as a parameter
        //public GenericRepositoryAsync(TDbContext context)
        //{
        //    //Initialize _isDisposed to false and then set the Context Object
        //    _isDisposed = false;
        //    Context = context;
        //}
        //The following Property is going to return the Context Object
        public TDbContext Context => unitOfWork.Context;

        //The following Property is going to set and return the Entity
        protected virtual DbSet<T> Entities
        {
            get { return _entities ?? (_entities = Context.Set<T>()); }
        }

        //Return all the Records from the Corresponding Table
        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            return await Entities.ToListAsync();
        }
        //Return a Record from the Coresponding Table based on the Primary Key
        public virtual async Task<T?> GetByIdAsync(object id)
        {
            return await Entities.FindAsync(id);
        }
        //The following Method is going to Insert a new entity into the table
        public virtual async Task InsertAsync(T entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Entity");
                }

                //if (Context == null || _isDisposed)
                //{
                //    unitOfWork.Context = new TDbContext();
                //}
                await Entities.AddAsync(entity);
                //commented out call to SaveChanges as Context save changes will be
                //called with Unit of work
                //Context.SaveChanges(); 
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleUnitOfWorkException(dbEx);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        //The following Method is going to Update an existing entity in the table
        public virtual async Task UpdateAsync(T entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException("Entity");
                }

                //if (Context is null || _isDisposed)
                //{
                //    Context = new TDbContext();
                //}
                _entities.Attach(entity);
                Context.Entry(entity).State = EntityState.Modified;
                await Task.CompletedTask;
                //commented out call to SaveChanges as Context save changes will be called with Unit of work
                //Context.SaveChanges(); 
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleUnitOfWorkException(dbEx);
                throw new Exception(_errorMessage, dbEx);
            }
        }
        //The following Method is going to Delete an existing entity from the table
        public virtual async Task DeleteAsync(T entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException("Entity");
                }

                //if (Context is null || _isDisposed)
                //{
                //    Context = new AppDbContext();
                //}

                Entities.Remove(entity);
                await Task.CompletedTask;
                //commented out call to SaveChanges as Context save changes will be called with Unit of work
                //Context.SaveChanges(); 
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleUnitOfWorkException(dbEx);
                throw new Exception(_errorMessage, dbEx);
            }
        }

        public async Task DeleteAsync(int id)
        {
            var entity = await _entities.FindAsync(id);
            if (entity != null)
            {
                _entities.Remove(entity);
            }
        }

        private void HandleUnitOfWorkException(DbEntityValidationException dbEx)
        {
            foreach (var validationErrors in dbEx.EntityValidationErrors)
            {
                foreach (var validationError in validationErrors.ValidationErrors)
                {
                    _errorMessage = _errorMessage + $"Property: {validationError.PropertyName} Error: {validationError.ErrorMessage} {Environment.NewLine}";
                }
            }
        }

        //The following Method is going to Dispose of the Context Object
        public async ValueTask DisposeAsync()
        {
            if (Context != null)
                await Context.DisposeAsync();
            _isDisposed = true;
        }

        public IQueryable<T> GetAll()
        {
            return _entities.AsQueryable();
        }
    }
}
