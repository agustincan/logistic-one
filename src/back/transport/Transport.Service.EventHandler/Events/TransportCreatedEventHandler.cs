using System;
using System.Threading;
using System.Threading.Tasks;
using MediatR;

namespace Transport.Service.EventHandler.Events
{
    internal class TransportCreatedEventHandler : INotificationHandler<TransportCreatedEvent>
    {
        private readonly IMediator mediator;

        public TransportCreatedEventHandler(IMediator mediator)
        {
            this.mediator = mediator;
        }
        public async Task Handle(TransportCreatedEvent notification, CancellationToken cancellationToken)
        {
            
            await mediator.Publish(notification, cancellationToken);
        }
    }
}
