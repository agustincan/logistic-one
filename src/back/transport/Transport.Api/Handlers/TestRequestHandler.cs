using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Transport.Api.Dtos;

namespace Transport.Api.Handlers
{
    public class TestRequestHandler : IRequestHandler<TestRequest, TestResponse>
    {
        public TestRequestHandler()
        {
            
        }
        public async Task<TestResponse> Handle(TestRequest request, CancellationToken cancellationToken)
        {
            var res = new TestResponse() { Nombre = request.Nombre };
            return await Task.FromResult(res);  
        }
    }
}
