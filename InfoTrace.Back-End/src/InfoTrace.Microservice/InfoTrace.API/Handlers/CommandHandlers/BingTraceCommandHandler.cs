using InfoTrace.API.Commands;
using InfoTrace.API.Services;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InfoTrace.API.Handlers.CommandHandlers
{
    public class BingTraceCommandHandler : IRequestHandler<BingTraceCommand,string>
    {
        private readonly IStaticPagesService staticPagesService;
        public BingTraceCommandHandler(IStaticPagesService staticPagesService)
        {
            this.staticPagesService = staticPagesService;
        }

        public async Task<string> Handle(BingTraceCommand request, CancellationToken cancellationToken)
        {
            var rs = await staticPagesService.GetBingStaticPagesAsync(request.keyword, request.site);
            return rs;
        }
    }
}
