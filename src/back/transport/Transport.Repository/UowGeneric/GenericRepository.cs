using Common.Core.Domain;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace Transport.Repository.UowGeneric
{
    public class GenericRepository<TModel, TKey, TDbContext> : IGenericRepository2<TKey, TModel>, IDisposable 
        where TKey : struct
        where TModel : EntityBaseGeneric<TKey>
        where TDbContext : DbContext, new()
    {
        private DbSet<TModel> _entities;
        private string _errorMessage = string.Empty;
        private bool _isDisposed;
        private readonly IUnitOfWorkGeneric<TDbContext> unitOfWork;

        public GenericRepository(IUnitOfWorkGeneric<TDbContext> unitOfWork)
        {
            this.unitOfWork = unitOfWork;
            _entities = this.unitOfWork.Context.Set<TModel>();
        }
        public TDbContext Context { get; set; }

        protected virtual DbSet<TModel> Entities
        {
            get { return _entities ?? (_entities = Context.Set<TModel>()); }
        }
        public void Dispose()
        {
            if (Context != null)
                Context.Dispose();
            _isDisposed = true;
        }
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
            }
            catch (ValidationException dbEx)
            {
                _errorMessage = dbEx.Message;
                throw new Exception(_errorMessage, dbEx);
            }
        }
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
            }
            catch (ValidationException dbEx)
            {
                _errorMessage = dbEx.Message;
                throw new Exception(_errorMessage, dbEx);
            }
        }
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
            }
            catch (ValidationException dbEx)
            {
                _errorMessage = dbEx.Message;
                throw new Exception(_errorMessage, dbEx);
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
