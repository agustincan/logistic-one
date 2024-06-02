using System.Threading.Tasks;
using Transport.Service.EventHandler.Command;

namespace Transport.Api.Services
{
    public interface ITransportServiceUow
    {
        Task<int> Insert(TransportCreateCommand data);
    }
}