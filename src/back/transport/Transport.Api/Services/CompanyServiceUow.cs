using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Domain.Models;
using Transport.Repository.Abstractions;

namespace Transport.Api.Services
{
    public class CompanyServiceUow : ICompanyServiceUow
    {
        private readonly ICompanyRepositoryUow repoUow;
        public CompanyServiceUow(ICompanyRepositoryUow repoUow)
        {
            this.repoUow = repoUow;
        }
        public async Task<IEnumerable<Company>> GetAllAsync()
        {
            return await repoUow.GetAllAsync();
        }
        public async Task<Company> GetByIdAsync(int id)
        {
            return await repoUow.GetByIdAsync(id);
        }
        public async Task<Company> CreateAsync(Company company)
        {
            return await repoUow.CreateAsync(company);
        }
        public async Task<bool> UpdateAsync(int id, Company company)
        {
            return await repoUow.UpdateAsync(id, company);
        }
        public async Task<bool> DeleteAsync(int id)
        {
            return await repoUow.DeleteAsync(id);
        }
        public async Task<bool> ExistsAsync(int id)
        {
            return await repoUow.ExistsAsync(id);
        }
    }
}
