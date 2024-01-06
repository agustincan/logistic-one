using Common.Core.Repository;
using Streets.Persistence.Database.Models;

namespace Streets.Application.Repositories
{
    public interface IStreetRepository: IRepositoryBase<Street, int>
    {
    }
}