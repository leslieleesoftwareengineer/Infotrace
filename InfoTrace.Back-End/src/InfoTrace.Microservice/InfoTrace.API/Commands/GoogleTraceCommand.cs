using Alamut.Abstractions.Caching;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrace.API.Commands
{
    public class GoogleTraceCommand:IRequest<string>, ICacheable
    {
        public string keyword { get; set; }
        public string site { get; set; }

        public string Key => $"{keyword}:{site}:GoogleTraceCommand";

        public ExpirationOptions Options => new ExpirationOptions(TimeSpan.FromSeconds(300));
    }
}
