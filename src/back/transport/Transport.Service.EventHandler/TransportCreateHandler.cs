using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Persistence;
using Transport.Service.EventHandler.Command;

namespace Transport.Service.EventHandler
{
    internal class TransportCreateHandler: INotification
    {
        private readonly AppDbContext context;

        public TransportCreateHandler(AppDbContext context)
        {
            this.context = context;
        }

        public async Task Handle(TransportCreateCommand notification, CancellationToken cancellationToken)
        {
            var trans = new Transportt()
            {
                Description = notification.Description,
                License = notification.License,
                Type = notification.Type,
                StatusMode = notification.StatusMode
            };
            await context.Transports.AddAsync(trans);
            await context.SaveChangesAsync();
        }
    }
}
