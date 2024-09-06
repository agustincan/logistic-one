using MediatR;

namespace Transport.Api.Dtos
{
    public class TestRequest: IRequest<TestResponse>
    {
        public string Nombre { get; set; }
    }
}
