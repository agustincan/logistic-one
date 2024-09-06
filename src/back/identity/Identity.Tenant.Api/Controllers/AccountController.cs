using Identity.Services.EvenHandlers.Commands;
using Identity.Services.EvenHandlers.Queries;
using Identity.Tenant.Api.Controllers.Base;
using Microsoft.AspNetCore.Mvc;

namespace Identity.Tenant.Api.Controllers
{
    public class AccountController : BaseApiCqrsController<AccountController>
    {
        public AccountController()
        {
            
        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return Ok();
        }

        [HttpGet]
        [Route("list-all")]
        public async Task<IActionResult> ListAll()
        {
            var result = await mediator.Send(new UserListByIds() { Ids = new int[] { 1,2 } });
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand command)
        {
            var res = await mediator.Send(command);
            if (res.Succeeded)
            {
                return Ok(res.Succeeded);
            }
            else
            {
                return BadRequest(new { res = res.Errors });
            }
        }
    }
}
