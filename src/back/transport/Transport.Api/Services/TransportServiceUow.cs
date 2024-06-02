using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Repository.Abstractions;
using Transport.Service.EventHandler.Command;

namespace Transport.Api.Services
{
    public class TransportServiceUow : ITransportServiceUow
    {
        private readonly ITransportRepositoryUow repoUow;

        public TransportServiceUow(ITransportRepositoryUow repoUow)
        {
            this.repoUow = repoUow;
        }

        public async Task<int> Insert(TransportCreateCommand data)
        {
            var t = new Transportt()
            {
                Description = data.Description,
                License = data.License,
                Type = data.Type
            };
            return await repoUow.Insert(t);
        } 
    }
}
