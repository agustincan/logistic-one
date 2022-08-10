using Domain.Common;

namespace Transport.Domain.Models
{
    public class Transportt
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public TransportType? Type { get; set; }
        public TransportMode? StatusMode { get; set; }
        public StatusType Status { get; set; } = StatusType.Enabled;

    }
}
