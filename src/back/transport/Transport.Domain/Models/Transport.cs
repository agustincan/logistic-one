using Common.Core.Domain;
using System.ComponentModel.DataAnnotations.Schema;

namespace Transport.Domain.Models
{
    [Table("Transports")]
    public class Transportt: EntityBaseGeneric<int>
    {
        public string Description { get; set; }
        public string License { get; set; }
        public TransportType? Type { get; set; }
        public TransportMode? StatusMode { get; set; }
        public StatusType Status { get; set; } = StatusType.Enabled;

    }
}
