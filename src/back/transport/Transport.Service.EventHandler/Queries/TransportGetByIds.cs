using Common.Core.Collections;
using Common.Core.Mapping;
using Common.Core.Persistence.Paging;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Dtos;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Queries
{
    public class TransportGetByIds: TransportBaseQuery, IRequest<DataCollection<TransportDto>>
    {
        public IEnumerable<int> ids { get; set; }
    }

    internal class TransportGetByIdsHandler : IRequestHandler<TransportGetByIds, DataCollection<TransportDto>>
    {
        private readonly AppDbContext context;

        public TransportGetByIdsHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<TransportDto>> Handle(TransportGetByIds request, CancellationToken cancellationToken)
        {
            var result = await context.Transports
                .Where(t => request.ids.Contains(t.Id))
                .OrderBy(t => t.Id)
                .GetPagedAsync(request.Page, request.Take);
            return result.MapTo<DataCollection<TransportDto>>();
        }
    }
}
