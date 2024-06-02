using Common.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.Data.Entity.Validation;

namespace Transport.Repository.UowGeneric
{
    public class GenericRepository<TModel, TKey, TDbContext> : IGenericRepository2<TKey, TModel>, IDisposable 
        //where T : class
        where TKey : struct
        where TModel : EntityBaseGeneric<TKey>
        where TDbContext : DbContext, new()
    {
        private DbSet<TModel> _entities;
        private string _errorMessage = string.Empty;
        private bool _isDisposed;
        private readonly IUnitOfWorkGeneric<TDbContext> unitOfWork;

        //While Creating an Instance of GenericRepository, we need to pass the UnitOfWork instance
        //That UnitOfWork instance contains the Context Object that our GenericRepository is going to use
        public GenericRepository(IUnitOfWorkGeneric<TDbContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _entities = this.unitOfWork.Context.Set<TModel>();
        }
        //If you don't want to use Unit of Work, then use the following Constructor 
        //which takes the context Object as a parameter
        //public GenericRepository(AppDbContext context)
        //{
        //    //Initialize _isDisposed to false and then set the Context Object
        //    _isDisposed = false;
        //    Context = context;
        //}
        //The following Property is going to return the Context Object
        public TDbContext Context { get; set; }

        //The following Property is going to set and return the Entity
        protected virtual DbSet<TModel> Entities
        {
            get { return _entities ?? (_entities = Context.Set<TModel>()); }
        }
        //The following Method is going to Dispose of the Context Object
        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            _isDisposed = true;
        }
        //Return all the Records from the Corresponding Table
        //public virtual IEnumerable<T> GetAll()
        //{
        //    return Entities.ToList();
        //}
        //Return a Record from the Coresponding Table based on the Primary Key
        //public virtual TModel? GetById(object id)
        //{
        //    return Entities.Find(id);
        //}
        //The following Method is going to Insert a new entity into the table
        public virtual void Insert(TModel entity)
        {
            try
            {
                if (entity == null)
                {
                    throw new ArgumentNullException("Entity");
                }

                if (Context == null || _isDisposed)
                {
                    Context = new TDbContext();
                }
                Entities.Add(entity);
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
        public virtual void Update(TModel entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException("Entity");
                }

                if (Context is null || _isDisposed)
                {
                    Context = new TDbContext();
                }
                Context.Entry(entity).State = EntityState.Modified;
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
        public virtual void Delete(TModel entity)
        {
            try
            {
                if (entity is null)
                {
                    throw new ArgumentNullException("Entity");
                }
                if (Context is null || _isDisposed)
                {
                    Context = new TDbContext();
                }

                Entities.Remove(entity);
                //commented out call to SaveChanges as Context save changes will be called with Unit of work
                //Context.SaveChanges(); 
            }
            catch (DbEntityValidationException dbEx)
            {
                HandleUnitOfWorkException(dbEx);
                throw new Exception(_errorMessage, dbEx);
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

        public TModel? GetById(object id)
        {
            return _entities.Find(id);
        }

        public IQueryable<TModel> GetAll()
        {
            return _entities.AsQueryable();
        }
    }
}
