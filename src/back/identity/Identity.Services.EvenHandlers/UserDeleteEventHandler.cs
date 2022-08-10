using Identity.Domain;
using Identity.Persistence;
using Identity.Services.EvenHandlers.Commands;
using Identity.Services.EvenHandlers.Responses;
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