using Common.Core.Collections;
using Common.Core.Paging;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Queries
{
    public class TransportListAll: TransportBaseQuery, IRequest<DataCollection<Transportt>>
    {
    }

    internal class TransportListAllHandler : IRequestHandler<TransportListAll, DataCollection<Transportt>>
    {
        private readonly AppDbContext context;

        public TransportListAllHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<Transportt>> Handle(TransportListAll request, CancellationToken cancellationToken)
        {
            var result = await context.Transports.OrderBy(t => t.Id)
                .GetPagedAsync(request.Page, request.Take);
            return result;
        }
    }
}
