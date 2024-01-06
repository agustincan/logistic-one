using LanguageExt;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Repository.Repos;

namespace Transport.Api.Services
{
    public class TransportServiceFunctional
    {
        private readonly ITransportRepositoryFunctional repository;

        public TransportServiceFunctional(ITransportRepositoryFunctional repository)
        {
            this.repository = repository;
        }

        //public async Task<Option<IEnumerable<Transportt>>> GetByIdsAsync(int[] Ids)
        //{
        //    return await repository.GetByIdsAsync(Ids);
        //}
    }
}
