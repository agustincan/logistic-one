using FluentValidation;
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
            try
            {
                return Ok(await mediator.Send(request));
            }
            catch(ValidationException ex)
            {
                return BadRequest(ex.Message);
            }
            catch (System.Exception)
            {

                throw;
            }
            
        }
    }
}
