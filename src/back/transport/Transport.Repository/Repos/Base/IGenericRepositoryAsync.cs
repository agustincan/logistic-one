using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Transport.Repository.Repos.Base
{
    //Here, we are creating the IGenericRepository interface as a Generic Interface
    //Here, we are applying the Generic Constraint 
    //The constraint is T which is going to be a class
    public interface IGenericRepositoryAsync<TModel, TDbContext>
        where TModel : class
        where TDbContext : DbContext, new()
    {
        //Task<IQueryable<TModel>> GetAllAsync();
        IQueryable<TModel> GetAll();
        Task<TModel?> GetByIdAsync(object id);
        Task InsertAsync(TModel obj);
        Task UpdateAsync(TModel obj);
        Task DeleteAsync(TModel obj);
        Task DeleteAsync(int id);
    }
}
