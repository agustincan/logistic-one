using Common.Core.Collections;
using Common.Core.Mapping;
using Common.Core.Paging;
using MediatR;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Dtos;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Queries
{
    public class TransportGetById: IRequest<TransportDto>
    {
        public int id { get; set; }
    }

    internal class TransportGetByIdHandler : IRequestHandler<TransportGetById, TransportDto>
    {
        private readonly AppDbContext context;

        public TransportGetByIdHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<TransportDto> Handle(TransportGetById request, CancellationToken cancellationToken)
        {
            var res = await context.Transports.FindAsync(request.id);
            return res?.MapTo<TransportDto>();
        }
    }
}
