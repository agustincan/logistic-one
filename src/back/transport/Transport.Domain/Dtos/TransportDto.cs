using Common.Core.Domain;
using Transport.Domain.Models;

namespace Transport.Domain.Dtos
{
    public class TransportDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public TransportType? Type { get; set; }
        public string TypeName { get { return Type.HasValue ? Type.Value.ToString() : ""; } }
        public TransportMode? StatusMode { get; set; }
        public string StatusModeName { get { return StatusMode.HasValue ? StatusMode.Value.ToString() : ""; } }
        public StatusType Status { get; set; }
    }

    //public record TransportDto( int Id );
}
