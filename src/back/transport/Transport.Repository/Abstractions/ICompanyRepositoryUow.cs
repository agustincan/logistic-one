using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Domain.Models;

namespace Transport.Repository.Abstractions
{
    public interface ICompanyRepositoryUow
    {
        Task<IEnumerable<Company>> GetAllAsync();
        Task<Company> GetByIdAsync(int id);
        Task<Company> CreateAsync(Company company);
        Task<bool> UpdateAsync(int id, Company company);
        Task<bool> DeleteAsync(int id);
        Task<bool> ExistsAsync(int id);
    }
}
