using Common.Core.Collections;
using Identity.Dtos;

namespace Identity.Services.Queries
{
    public interface IUserQueryTenantService
    {
        Task<SystemUserDto> GetAsync(string id);
        Task<DataCollection<SystemUserDto>> GetByEmailAsync(int page, int take, IEnumerable<string> emails);
        Task<DataCollection<SystemUserDto>> GetByUserAsync(int page, int take, IEnumerable<string> users);
    }
}
