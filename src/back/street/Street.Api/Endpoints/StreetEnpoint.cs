using Carter;

namespace Streets.Api.Endpoints
{
    public sealed class StreetEnpoint: ICarterModule
    {

        public void AddRoutes(IEndpointRouteBuilder app)
        {
            var group = app.MapGroup("api/street")
                .WithOpenApi();

            group.MapGet("list-by-ids", ListByIds);
            group.MapPost("list-by-ids", ListByIds);
            //group.MapPost("status", PostStatus);
        }

        public async Task<IResult> ListByIds(int[] ids)
        {

            return Results.Ok(await Task.FromResult($"get api street list by ids minimal running ..{ids}"));
        }
    }
}
