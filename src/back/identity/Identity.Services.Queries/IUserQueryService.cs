using Common.Core.Collections;
using Common.Core.Domain;
using Identity.Dtos;

namespace Identity.Services.Queries
{
    public interface IUserQueryService
    {
        Task<ApplicationUser> GetAsync(string id);
        Task<DataCollection<ApplicationUser>> GetByEmailAsync(int page, int take, IEnumerable<string> emails);
        Task<DataCollection<ApplicationUser>> GetByUserAsync(int page, int take, IEnumerable<string> users);
    }
}
