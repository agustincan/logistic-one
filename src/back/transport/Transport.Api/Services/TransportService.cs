using LanguageExt;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Repository.Repos;

namespace Transport.Api.Services
{
    public interface ITransportService
    {
        Task<Option<Transportt>> GetByIdAsync(int Id);
        Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids);
    }

    public class TransportService : ITransportService
    {
        private readonly ITransportRepository repository;

        public TransportService(ITransportRepository repository)
        {
            this.repository = repository;
        }

        public async Task<Option<Transportt>> GetByIdAsync(int Id)
        {
            return await repository.GetByIdAsync(Id);
        }

        public async Task<IEnumerable<Transportt>> GetByIdsAsync(int[] Ids)
        {
            return await repository.GetByIdsAsync(Ids);
        }
    }
}
