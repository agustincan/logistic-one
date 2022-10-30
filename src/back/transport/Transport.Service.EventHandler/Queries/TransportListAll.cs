using Common.Core.Collections;
using Common.Core.Mapping;
using Common.Core.Paging;
using MediatR;
using MediatR.Wrappers;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Dtos;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Queries
{
    public class TransportListAll: TransportBaseQuery, IRequest<DataCollection<TransportDto>>
    {
    }

    internal class TransportListAllHandler : IRequestHandler<TransportListAll, DataCollection<TransportDto>>
    {
        private readonly AppDbContext context;

        public TransportListAllHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<TransportDto>> Handle(TransportListAll request, CancellationToken cancellationToken)
        {
            var result = await context.Transports.OrderBy(t => t.Id)
                .GetPagedAsync(request.Page, request.Take);
            return result.MapTo<DataCollection<TransportDto>>();
        }
    }
}
