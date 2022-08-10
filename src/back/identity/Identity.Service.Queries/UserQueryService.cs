using Identity.Service.Queries.Dtos;
using Service.Common.Collection;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Identity.Service.Queries
{
    public interface IUserQueryService
    {
        Task<DataCollection<SystemUserDto>> GetAllAsync(int page, int take, IEnumerable<string> users);
        Task<SystemUserDto> GetAsync(string id);
        Task<DataCollection<SystemUserDto>> GetByEmailAsync(int page, int take, IEnumerable<string> emails);
    }

    public class UserQueryService : IUserQueryService
    {
        private readonly AppDbContext context;

        public UserQueryService(AppDbContext context)
        {
            this.context = context;
        }
        public async Task<DataCollection<SystemUserDto>> GetAllAsync(int page, int take, IEnumerable<string> users)
        {
            var collection = await context.Users
                .Where(x => users == null || users.Contains(x.Id))
                .OrderBy(x => x.FirstName)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<SystemUserDto>>();
        }

        public async Task<DataCollection<SystemUserDto>> GetByEmailAsync(int page, int take, IEnumerable<string> emails)
        {
            var collection = await context.Users
                .Where(x => emails == null || emails.Contains(x.Email))
                .OrderBy(x => x.FirstName)
                .GetPagedAsync(page, take);

            return collection.MapTo<DataCollection<SystemUserDto>>();
        }

        public async Task<SystemUserDto> GetAsync(string id)
        {
            return (await context.Users.SingleAsync(x => x.Id == id)).MapTo<SystemUserDto>();
        }
    }
}