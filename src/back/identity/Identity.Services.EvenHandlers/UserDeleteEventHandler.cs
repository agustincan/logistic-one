using Common.Core.Identity.Domain;
using Identity.Services.EvenHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.EvenHandlers
{

    public class UserDeleteEventHandler : IRequestHandler<UserDeleteCommand, int>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserDeleteEventHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<int> Handle(UserDeleteCommand command, CancellationToken cancelationToken)
        {
            //var result = await context.SystemUsers.FindAsync(command.Id);
            //if (result == null) return await Task.FromResult(0);

            //result.IsActive = false;
            //return await context.SaveChangesAsync();
            return await Task.FromResult(1);
        }
    }
}