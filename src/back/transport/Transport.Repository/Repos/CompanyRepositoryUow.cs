using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Persistence;
using Microsoft.EntityFrameworkCore;
using Transport.Repository.Abstractions;
using Transport.Repository.UowGeneric;

namespace Transport.Repository.Repos
{
    public class CompanyRepositoryUow : ICompanyRepositoryUow
    {
        private readonly IUnitOfWorkGeneric<AppDbContext> uow;
        public CompanyRepositoryUow(IUnitOfWorkGeneric<AppDbContext> uow)
        {
            this.uow = uow;
        }
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await uow.Context.Companies.ToListAsync();
        }
        public async Task<Company> GetByIdAsync(int id)
        {
            return await uow.Context.Companies.FindAsync(id);
        }
        public async Task<Company> CreateAsync(Company company)
        {
            uow.Context.Companies.Add(company);
            await uow.SaveAsync();
            return company;
        }
        public async Task<bool> UpdateAsync(int id, Company company)
        {
            if (id != company.Id) return false;
            uow.Context.Entry(company).State = EntityState.Modified;
            try
            {
                await uow.SaveAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!await ExistsAsync(id))
                    return false;
                else
                    throw;
            }
        }
        public async Task<bool> DeleteAsync(int id)
        {
            var company = await uow.Context.Companies.FindAsync(id);
            if (company == null) return false;
            uow.Context.Companies.Remove(company);
            await uow.SaveAsync();
            return true;
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await uow.Context.Companies.AnyAsync(e => e.Id == id);
        }
    }
}
