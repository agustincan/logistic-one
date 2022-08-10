using Domain.Common;
using MediatR;
using Transport.Domain.Models;

namespace Transport.Service.EventHandler.Command
{
    public class TransportCreateCommand : INotification
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public TransportType? Type { get; set; }
        public string TypeName { get; set; }
        public TransportMode? StatusMode { get; set; }
        public StatusType Status { get; set; } = StatusType.Enabled;
    }

    public class TransportCreateCommand2 : IRequest<Transportt>
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public TransportType? Type { get; set; }
        public string TypeName { get; set; }
        public TransportMode? StatusMode { get; set; }
        public StatusType Status { get; set; } = StatusType.Enabled;
    }

    //public record TransportCreateCommand3(Transportt transport) : IRequest<Transportt>;
}
