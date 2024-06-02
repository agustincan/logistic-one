using Transport.Domain.Models;
using Transport.Persistence;
using Transport.Repository.Abstractions;
using Transport.Repository.UowGeneric;

namespace Transport.Repository.Repos
{
    public class TransportRepositoryUow : ITransportRepositoryUow
    {
        private readonly IUnitOfWorkGeneric<AppDbContext> uow;

        public TransportRepositoryUow(IUnitOfWorkGeneric<AppDbContext> uow)
        {
            this.uow = uow;
        }

        public async Task<int> Insert(Transportt data)
        {
            uow.Context.Transports.Add(data);
            var data2 = new Company() {

               Name = "Description " + DateTime.Now,
               Test = 45
            };
            
            uow.Context.Companies.Add(data2);
            return await uow.SaveAsync();
        }
    }
}
