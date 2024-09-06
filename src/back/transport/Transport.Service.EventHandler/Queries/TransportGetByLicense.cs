using Common.Core.Collections;
using Common.Core.Paging;
using LanguageExt;
using MediatR;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Queries
{
    public class TransportGetByLicenseOption : TransportBaseQuery, IRequest<Option<DataCollectionOption<Transportt>>>
    {
        public string License { get; set; }
    }

    internal class TransportGetByLicenseOptionHandler : IRequestHandler<TransportGetByLicenseOption, Option<DataCollectionOption<Transportt>>>
    {
        private readonly AppDbContext context;

        public TransportGetByLicenseOptionHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Option<DataCollectionOption<Transportt>>> Handle(TransportGetByLicenseOption request, CancellationToken cancellationToken)
        {
            var result = await context.Transports
                .Where(t => t.License.Contains(request.License))
                .OrderBy(t => t.Id)
                .GetPagedOptionAsync(request.Page, request.Take);
            return result;
        }
    }

    public class TransportGetByLicense : TransportBaseQuery, IRequest<DataCollection<Transportt>>
    {
        public string License { get; set; }
    }

    internal class TransportGetByLicenseHandler : IRequestHandler<TransportGetByLicense, DataCollection<Transportt>>
    {
        private readonly AppDbContext context;

        public TransportGetByLicenseHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<Transportt>> Handle(TransportGetByLicense request, CancellationToken cancellationToken)
        {
            var result = await context.Transports
                .Where(t => t.License.Contains(request.License))
                .OrderBy(t => t.Id)
                .GetPagedAsync(request.Page, request.Take);
    
            return result;
        }
    }
}
