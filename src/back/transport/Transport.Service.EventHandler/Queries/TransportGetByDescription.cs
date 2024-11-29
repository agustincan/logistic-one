using Common.Core.Collections;
using Common.Core.Mapping;
using Common.Core.Paging;
using Common.Core.Persistence.Paging;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Dtos;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Queries
{
    public class TransportGetByDescription: TransportBaseQuery, IRequest<DataCollection<TransportDto>>
    {
        public string Description { get; set; }
    }

    internal class TransportGetByDescriptionHandler : IRequestHandler<TransportGetByDescription, DataCollection<TransportDto>>
    {
        private readonly AppDbContext context;

        public TransportGetByDescriptionHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<TransportDto>> Handle(TransportGetByDescription request, CancellationToken cancellationToken)
        {
            var result = await context.Transports
                .Where(t => t.Description.Contains(request.Description))
                .OrderBy(t => t.Id)
                .GetPagedAsync(request.Page, request.Take);
            return result.MapTo<DataCollection<TransportDto>>();
        }
    }
}
