using Identity.Domain;
using Identity.Persistence;
using Identity.Services.EvenHandlers.Commands;
using Identity.Services.EvenHandlers.Responses;
using MediatR;
using Microsoft.AspNetCore.Identity;

namespace Identity.Services.EvenHandlers
{
    public class UserCreateEventHandler: IRequestHandler<UserCreateCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public UserCreateEventHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }

        public async Task<IdentityResult> Handle(UserCreateCommand command, CancellationToken cancelationToken)
        {
            var newUser = new ApplicationUser()
            {
                Email = command.Email,
                FirstName = command.FirstName,
                LastName = command.LastName,
                UserName = command.UserName
            };
            return await userManager.CreateAsync(newUser, command.Password);
        }
    }
}