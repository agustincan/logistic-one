using Common.Core.Persistence.Repository;
using Streets.Persistence.Database.Models;

namespace Streets.Application.Repositories
{
    public interface IStreetRepository : IRepositoryBase<Street, int>
    {
        Task Copy3000();
        Task Copy3000Raw();
        Task Insert7000();
    }
}