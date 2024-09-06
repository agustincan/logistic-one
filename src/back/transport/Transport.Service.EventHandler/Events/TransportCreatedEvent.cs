using MediatR;

namespace Transport.Service.EventHandler.Events
{
    internal class TransportCreatedEvent: INotification
    {
        public int NewId { get; set; }
        public string Message { get; set; }
    }
}
