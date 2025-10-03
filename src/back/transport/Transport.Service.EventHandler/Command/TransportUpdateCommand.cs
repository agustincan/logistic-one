using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Transport.Domain.Models;
using Common.Core.Domain;
using Transport.Persistence;

namespace Transport.Service.EventHandler.Command
{
    public class TransportUpdateCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public TransportType? Type { get; set; }
        public string TypeName { get; set; }
        public TransportMode? StatusMode { get; set; }
        public StatusType Status { get; set; } = StatusType.Enabled;
    }

    internal class TransportUpdateHandler : IRequestHandler<TransportUpdateCommand, bool>
    {
        private readonly AppDbContext context;

        public TransportUpdateHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<bool> Handle(TransportUpdateCommand request, CancellationToken cancellationToken)
        {
            var transport = await context.Transports.FindAsync(request.Id);
            if (transport == null)
                return false;

            transport.Description = request.Description;
            transport.License = request.License;
            transport.Type = request.Type;
            transport.StatusMode = request.StatusMode;
            transport.Status = request.Status;

            context.Entry(transport).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            
            try
            {
                await context.SaveChangesAsync(cancellationToken);
                return true;
            }
            catch (Microsoft.EntityFrameworkCore.DbUpdateConcurrencyException)
            {
                if (!await context.Transports.AnyAsync(e => e.Id == request.Id, cancellationToken))
                    return false;
                else
                    throw;
            }
        }
    }
}
