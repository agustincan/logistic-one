using MediatR;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Transport.Api.Dtos;

namespace Transport.Api.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class TestCqrsController: BaseApiCqrsController<TestCqrsController>
    {
        //private readonly IMediator mediator;

        //public TestCqrsController(IMediator mediator)
        //{
        //    this.mediator = mediator;
        //}

        [HttpGet]
        [Route("test-pipelines")]
        public async Task<IActionResult> TestPipelines([FromQuery] TestRequest request)
        {

            return Ok(await mediator.Send(request));
        }
    }
}
