using Common.Core.Collections;
using Common.Core.Domain;

namespace Identity.Services.Queries
{
    public interface IUserQueryTenantService
    {
        Task<ApplicationUser> GetAsync(string id);
        Task<DataCollection<ApplicationUser>> GetByEmailAsync(int page, int take, IEnumerable<string> emails);
        Task<DataCollection<ApplicationUser>> GetByUserAsync(int page, int take, IEnumerable<string> users);
    }
}
