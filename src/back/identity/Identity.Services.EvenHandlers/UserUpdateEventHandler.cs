using Identity.Domain;
using Identity.Persistence;
using Identity.Services.EvenHandlers.Commands;
using Identity.Services.EvenHandlers.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.EvenHandlers
{
    public class UserUpdateEventHandler: IRequestHandler<UserUpdateCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserUpdateEventHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> Handle(UserUpdateCommand command, CancellationToken cancelationToken)
        {
            var aUser = await userManager.FindByEmailAsync(command.Email);
            if (aUser == null) throw new Exception($"User by email {command.Email} not found");
            
            aUser.FirstName = command.FirstName;
            aUser.LastName = command.LastName;
            return await userManager.UpdateAsync(aUser);
        }
    }
}