using LanguageExt;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Queries
{
    public class TransportGetById: IRequest<Option<Transportt>>
    {
        public int id { get; set; }
    }

    internal class TransportGetByIdHandler : IRequestHandler<TransportGetById, Option<Transportt>>
    {
        private readonly AppDbContext context;

        public TransportGetByIdHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Option<Transportt>> Handle(TransportGetById request, CancellationToken cancellationToken)
        {
            return await context.Transports.FindAsync(request.id);
        }
    }
}
