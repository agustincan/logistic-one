using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Persistence;
using Transport.Service.EventHandler.Command;

namespace Transport.Service.EventHandler
{
    internal class TransportCreateHandler2 : IRequestHandler<TransportCreateCommand2, Transportt>
    {
        private readonly AppDbContext context;

        public TransportCreateHandler2(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<Transportt> Handle(TransportCreateCommand2 request, CancellationToken cancellationToken)
        {
            var trans = new Transportt()
            {
                Description = request.Description,
                License = request.License,
                Type = request.Type,
                StatusMode = request.StatusMode
            };
            await context.Transports.AddAsync(trans);
            await context.SaveChangesAsync();
            return trans ;

        }
    }
}
