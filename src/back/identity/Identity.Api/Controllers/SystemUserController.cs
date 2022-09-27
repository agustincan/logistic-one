using Common.Core.Collections;
using Identity.Dtos;
using Identity.Services.EvenHandlers.Commands;
using Identity.Services.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Identity.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class SystemUserController : ControllerBase
    {
        private readonly IUserQueryService queryService;
        private readonly IMediator mediator;

        public SystemUserController(IUserQueryService queryService, IMediator mediator)
        {
            this.queryService = queryService;
            this.mediator = mediator;
        }

        [HttpGet()]
        [Route("user/{user}")]
        public async Task<DataCollection<SystemUserDto>> GetByUser(string user)
        {
            return await queryService.GetByUserAsync(1, 10, new string[] { user });
        }

        [HttpGet]
        [Route("email/{email}")]
        public async Task<DataCollection<SystemUserDto>> GetByEmail(string email)
        {
            return await queryService.GetByEmailAsync(1,10, new string[] { email });
        }

        [HttpPost]
        public async Task<IActionResult> Create(UserCreateCommand command)
        {
            var res = await mediator.Send(command);
            if (res.Succeeded)
            {
                return Ok(res.Succeeded);
            } else {
                return BadRequest( new { res = res.Errors } );
            }
        }

        [HttpPost("authentication")]
        public async Task<IActionResult> Authentication(UserLoginCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await mediator.Send(command);

                if (!result.Succeeded)
                {
                    return BadRequest("Access denied");
                }

                return Ok(result);
            }

            return BadRequest();
        }

        // PUT api/<ValuesController>/5
        //[HttpPut("{id}")]
        //public void Put(int id, [FromBody] string value)
        //{
        //}

        // DELETE api/<ValuesController>/5
        //[HttpDelete("{id}")]
        //public void Delete(int id)
        //{

        //}
    }
}
