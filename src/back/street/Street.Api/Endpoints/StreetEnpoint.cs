using Carter;
using Streets.Application.Services;
using System.Diagnostics;

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
            group.MapPost("insert-7000", Insert7000);
            group.MapPost("copy-3000", Copy3000);
            group.MapPost("copy-3000-raw", Copy3000Raw);
            //group.MapPost("status", PostStatus);
        }

        private async Task<IResult> Copy3000(IStreetService streetService)
        {
            var sw = new Stopwatch();
            sw.Start();
            await streetService.Copy3000();
            sw.Stop();
            return Results.Ok(sw.ElapsedMilliseconds);
        }

        private async Task<IResult> Copy3000Raw(IStreetService streetService)
        {
            var sw = new Stopwatch();
            sw.Start();
            await streetService.Copy3000Raw();
            sw.Stop();
            return Results.Ok(sw.ElapsedMilliseconds);
        }

        private async Task<IResult> Insert7000(IStreetService streetService)
        {
            var sw = new Stopwatch();
            sw.Start();
            await streetService.Insert7000();
            sw.Stop();
            return Results.Ok(sw.ElapsedMilliseconds);
        }

        private async Task<IResult> ListByIds(int[] ids)
        {

            return Results.Ok(await Task.FromResult($"get api street list by ids minimal running ..{ids}"));
        }
    }
}
