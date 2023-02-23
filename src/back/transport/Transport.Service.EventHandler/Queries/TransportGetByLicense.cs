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
    public class TransportGetByLicense : TransportBaseQuery, IRequest<Option<DataCollectionOption<Transportt>>>
    {
        public string License { get; set; }
    }

    internal class TransportGetByLicenseHandler : IRequestHandler<TransportGetByLicense, Option<DataCollectionOption<Transportt>>>
    {
        private readonly AppDbContext context;

        public TransportGetByLicenseHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Option<DataCollectionOption<Transportt>>> Handle(TransportGetByLicense request, CancellationToken cancellationToken)
        {
            var result = await context.Transports
                .Where(t => t.License.Contains(request.License))
                .OrderBy(t => t.Id)
                .GetPagedOptionAsync(request.Page, request.Take);
            return result;
        }
    }
}
