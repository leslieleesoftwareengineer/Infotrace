using InfoTrace.API.Commands;
using InfoTrace.API.Services;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace InfoTrace.API.Handlers.CommandHandlers
{
    public class GoogleTraceCommandHandler : IRequestHandler<GoogleTraceCommand, string>
    {
        private readonly IStaticPagesService staticPagesService;

        public GoogleTraceCommandHandler(IStaticPagesService staticPagesService)
        {
            this.staticPagesService = staticPagesService;
        }

        public async Task<string> Handle(GoogleTraceCommand request, CancellationToken cancellationToken)
        {
            var rs = await staticPagesService.GetGoogleStaticPagesAsync(request.keyword, request.site);
            return rs;
        }
    }
}
