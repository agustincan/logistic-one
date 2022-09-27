using Common.Core.Domain;
using Common.Core.Multitenancy;
using Identity.Services.EvenHandlers.Commands;
using MediatR;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;

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
            var result = await userManager.CreateAsync(newUser, command.Password);

            var customClaims = new List<Claim>()
            {
                new Claim(ConstantsMultitenancy.ClaimTenantId, newUser.Id)
            };

            await userManager.AddClaimsAsync(newUser, customClaims);

            return result;
        }
    }
}