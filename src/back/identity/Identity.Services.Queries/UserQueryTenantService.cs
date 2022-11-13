using Common.Core.Collections;
using Common.Core.Domain;
using Common.Core.Paging;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services.Queries
{
    public class UserQueryTenantService : IUserQueryTenantService
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserQueryTenantService(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<DataCollection<ApplicationUser>> GetByUserAsync(int page, int take, IEnumerable<string> users)
        {
            var collection = await userManager.Users
                .Where(x => users == null || users.Contains(x.UserName))
                .OrderBy(x => x.FirstName)
                .GetPagedAsync(page, take);

            return collection;
        }

        public async Task<DataCollection<ApplicationUser>> GetByEmailAsync(int page, int take, IEnumerable<string> emails)
        {
            var collection = await userManager.Users
                .Where(x => emails == null || emails.Contains(x.Email))
                .OrderBy(x => x.FirstName)
                .GetPagedAsync(page, take);

            return collection;
        }

        public async Task<ApplicationUser> GetAsync(string id)
        {
            return await userManager.Users.SingleAsync(x => x.Id == id);
        }
    }
}