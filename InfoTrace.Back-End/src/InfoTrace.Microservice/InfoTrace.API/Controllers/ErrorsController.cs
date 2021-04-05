using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrace.API.Controllers
{
    [ApiController]
    public class ErrorsController : ControllerBase
    {
        private readonly ILogger<ErrorsController> _logger;

        public ErrorsController(ILogger<ErrorsController> logger)
        {
            _logger = logger;
        }

        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult Error()
        {
            var context = HttpContext.Features.Get<IExceptionHandlerFeature>();
            var traceId = Activity.Current?.Id ?? HttpContext?.TraceIdentifier;
            _logger.LogError($"{traceId}::{context.Error.Message}");
            _logger.LogError($"{traceId}::{context.Error.StackTrace}");
            return Problem(detail: null,
                title: context.Error.Message);
        }
    }
}
