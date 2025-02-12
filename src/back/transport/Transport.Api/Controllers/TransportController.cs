﻿using Common.Core.Collections;
using Common.Core.Mapping;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Threading.Tasks;
using Transport.Api.ActionFilters;
using Transport.Api.Services;
using Transport.Domain.Dtos;
using Transport.Service.EventHandler.Command;
using Transport.Service.EventHandler.Queries;

namespace Transport.Api.Controllers
{
    public sealed class TransportController : BaseApiCqrsController<TransportController>
    {
        private readonly ITransportService transportService;

        public TransportController(
            ITransportService transportService )
        {
            this.transportService = transportService;
        }

        //[MapToApiVersion("1.0")]
        [HttpGet]
        public async Task<DataCollection<TransportDto>> Get(int page = 1, int take = 20) 
        {
            var result = await mediator.Send(new TransportListAll() { Page = page, Take = take });
            Logger.LogInformation("Get trasnport all executed");
            return result.MapTo<DataCollection<TransportDto>>();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            //var resultOption = await mediator.Send(new TransportGetById() { id = id });
            ////resultOption.Filter(x => x.Status == Common.Core.Domain.StatusType.Enabled);
            //var result = resultOption.Map(r => r.MapTo<TransportDto>());
            //return result.Match<IActionResult>(Ok, NotFound);

            var resultOptionRepo = await transportService.GetByIdAsync(id);

            return resultOptionRepo
                .Map(r => r.MapTo<TransportDto>())
                .Match<IActionResult>(Ok, NotFound);
        }

        [HttpGet("license-option/{license}")]
        public async Task<IActionResult> GetByLicenseOption(string license)
        {
            var result = (await mediator.Send(new TransportGetByLicenseOption() { License = license }));
            //result.Items.Map(i => i.MapTo<TransportDto>());
            return result
                .Map(r => r.Items.Map(rr => rr.MapTo<TransportDto>()))
                .Match<IActionResult>(r => Ok(r), NotFound);
        }

        [HttpGet("license/{license}")]
        public async Task<IActionResult> GetByLicense(string license)
        {
            var result = (await mediator.Send(new TransportGetByLicense() { License = license }));
            //result.Items.Map(i => i.MapTo<TransportDto>());
            return Ok(result.MapTo<TransportDto>());
        }

        [HttpGet("license2")]
        public async Task<IActionResult> GetByLicense2([FromQuery]TransportGetByLicense request)
        {
            return Ok(await Task.FromResult(request));
        }

        [HttpPost("by-ids")]
        public async Task<IActionResult> GetByIds(int[] ids)
        {
            //var result = await repo.GetByIdsAsync(ids);
            var result = await transportService.GetByIdsAsync(ids);
            //result.Items.Map(i => i.MapTo<TransportDto>());
            return Ok(result.MapTo<IEnumerable<TransportDto>>());
                //.Map(r => r.Items.Map(rr => rr.MapTo<TransportDto>()))
                //.Match<IActionResult>(r => Ok(r), NotFound);
        }

        [HttpPost]
        [ServiceFilter(typeof(AuthActionFilter))]
        public async Task<IActionResult> Create([FromBody]TransportCreateCommand command)
        {
            var result = await mediator.Send(command);
            //return CreatedAtAction(nameof(Create), new { id = resultOption. }, product);
            return Ok(result);
            //return resultOption
            //    .Match<IActionResult>(r => Ok(new { id = r }), NoContent); 
            //Ok(new { id = res });
        }

        
    }
}
