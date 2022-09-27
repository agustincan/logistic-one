using Common.Core.Collections;
using Common.Core.Mapping;
using Common.Core.Paging;
using MediatR;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Dtos;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Queries
{
    public class TransportGetByLicense : TransportBaseQuery, IRequest<DataCollection<TransportDto>>
    {
        public string License { get; set; }
    }

    internal class TransportGetByLicenseHandler : IRequestHandler<TransportGetByLicense, DataCollection<TransportDto>>
    {
        private readonly AppDbContext context;

        public TransportGetByLicenseHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<TransportDto>> Handle(TransportGetByLicense request, CancellationToken cancellationToken)
        {
            var result = await context.Transports
                .Where(t => t.License.Contains(request.License))
                .OrderBy(t => t.Id)
                .GetPagedAsync(request.Page, request.Take);
            return result.MapTo<DataCollection<TransportDto>>();
        }
    }
}
