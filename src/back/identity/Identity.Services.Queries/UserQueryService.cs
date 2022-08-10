using Identity.Dtos;
using Identity.Persistence.Database;
using Microsoft.EntityFrameworkCore;
using Service.Common.Collection;
using Service.Common.Mapping;
using Service.Common.Paging;

namespace Identity.Services.Queries
{
    public interface IUserQueryService
    {
        Task<SystemUserDto> GetAsync(string id);
        Task<DataCollection<SystemUserDto>> GetByEmailAsync(int page, int take, IEnumerable<string> emails);
        Task<DataCollection<SystemUserDto>> GetByUserAsync(int page, int take, IEnumerable<string> users);
    }

    public class UserQueryService : IUserQueryService
    {
        private readonly AppDbContext context;

        public UserQueryService(AppDbContext context)
        {
            this.context = context;
        }
        //public async Task<DataCollection<SystemUserDto>> GetAllAsync(int page, int take, IEnumerable<string> users)
        //{
        //    var collection = await context.Users
        //        .Where(x => users == null || users.Contains(x.Id))
        //        .OrderBy(x => x.FirstName)
        //        .GetPagedAsync(page, take);

        //    return collection.MapTo<DataCollection<SystemUserDto>>();
        //}

        public async Task<DataCollection<SystemUserDto>> GetByUserAsync(int page, int take, IEnumerable<string> users)
        {
            var collection = await context.Users
                .Where(x => users == null || users.Contains(x.UserName))
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