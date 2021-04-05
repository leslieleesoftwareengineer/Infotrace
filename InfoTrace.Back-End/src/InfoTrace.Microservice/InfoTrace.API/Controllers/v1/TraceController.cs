using InfoTrace.API.Commands;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
namespace InfoTrace.API.Controllers.v1
{
    [Route("v1/api/[controller]")]
    [ApiController]
    public class TraceController : ControllerBase
    {
        private readonly IMediator mediator;

        public TraceController(IMediator mediator)
        {
            this.mediator = mediator;
        }
        [HttpPost("google")]
        public async Task<IActionResult> google(GoogleTraceCommand googleTraceCommand)
        {
            var rs = await mediator.Send(googleTraceCommand);
            return rs == null? NotFound():Ok(rs);
        }
        [HttpPost("bing")]
        public async Task<IActionResult> bing(BingTraceCommand bingTraceCommand)
        {
            var rs = await mediator.Send(bingTraceCommand);
            return rs == null ? NotFound() : Ok(rs);
        }
    }
}
