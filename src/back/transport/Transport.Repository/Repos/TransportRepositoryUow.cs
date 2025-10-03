using Transport.Domain.Models;
using Transport.Persistence;
using Transport.Repository.Abstractions;
using Transport.Repository.UowGeneric;
using Microsoft.EntityFrameworkCore;

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

        public async Task<bool> Update(int id, Transportt data)
        {
            if (id != data.Id) return false;
            uow.Context.Entry(data).State = EntityState.Modified;
            try
            {
                await uow.SaveAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await uow.Context.Transports.AnyAsync(e => e.Id == id))
                    return false;
                else
                    throw;
            }
        }
    }
}
