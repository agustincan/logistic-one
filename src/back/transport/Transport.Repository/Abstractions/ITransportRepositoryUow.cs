using Transport.Domain.Models;

namespace Transport.Repository.Abstractions
{
    public interface ITransportRepositoryUow
    {
        Task<int> Insert(Transportt data);
        Task<bool> Update(int id, Transportt data);
    }
}