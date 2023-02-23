using MediatR;
using System.Threading.Tasks;
using System.Threading;
using Transport.Domain.Models;
using Common.Core.Domain;
using Transport.Persistence;
using LanguageExt;

namespace Transport.Service.EventHandler.Command
{
    public class TransportCreateCommand : IRequest<Option<int>>
    {
        //public int Id { get; set; }
        public string Description { get; set; }
        public string License { get; set; }
        public TransportType? Type { get; set; }
        public string TypeName { get; set; }
        public TransportMode? StatusMode { get; set; }
        public StatusType Status { get; set; } = StatusType.Enabled;
    }

    internal class TransportCreateHandler : IRequestHandler<TransportCreateCommand, Option<int>>
    {
        private readonly AppDbContext context;

        public TransportCreateHandler(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Option<int>> Handle(TransportCreateCommand request, CancellationToken cancellationToken)
        {
            var transport = new Transportt()
            {
                Description = request.Description,
                License = request.License,
                Type = request.Type,
                StatusMode = request.StatusMode
            };
            await context.Transports.AddAsync(transport);
            await context.SaveChangesAsync();
            return transport.Id;

        }
    }
}
