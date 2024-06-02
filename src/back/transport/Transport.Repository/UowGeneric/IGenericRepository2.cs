namespace Transport.Repository.UowGeneric
{
    //Here, we are creating the IGenericRepository interface as a Generic Interface
    //Here, we are applying the Generic Constraint 
    //The constraint is T which is going to be a class
    public interface IGenericRepository2<TKey, TModel> 
        where TKey : struct
        where TModel : class
    {
        IQueryable<TModel> GetAll();
        TModel? GetById(object id);
        void Insert(TModel obj);
        void Update(TModel obj);
        void Delete(TModel obj);
    }
}
