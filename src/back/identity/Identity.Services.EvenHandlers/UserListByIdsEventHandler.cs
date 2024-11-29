using Common.Core.Identity.Domain;
using Common.Core.Mapping;
using Identity.Dtos;
using Identity.Services.EvenHandlers.Queries;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Identity.Services.EvenHandlers
{
    public class UserListByIdsEventHandler: IRequestHandler<UserListByIds, List<SystemUserDto>>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserListByIdsEventHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<List<SystemUserDto>> Handle(UserListByIds req, CancellationToken cancellationToken)
        {
            var idsstr = Array.ConvertAll(req.Ids, e => e.ToString());
            //var res = await userManager.Users.Where(u => idsstr.Contains(u.Id)).ToListAsync();
            var res = await userManager.Users.ToListAsync();
            return res.MapTo<List<SystemUserDto>>();
        }
    }
}
