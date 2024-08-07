﻿namespace Transport.Repository.UowGeneric
{
    //Here, we are creating the IGenericRepository interface as a Generic Interface
    //Here, we are applying the Generic Constraint 
    //The constraint is T which is going to be a class
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        T GetById(object id);
        void Insert(T obj);
        void Update(T obj);
        void Delete(T obj);
    }
}
