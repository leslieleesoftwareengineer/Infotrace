using FluentValidation;
using InfoTrace.API.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrace.API.Validations
{
    public class GoogleTraceCommandValidation:AbstractValidator<GoogleTraceCommand>
    {
        public GoogleTraceCommandValidation()
        {
            RuleFor(x => x.keyword).NotEmpty().NotNull();
            RuleFor(x => x.site).NotEmpty().NotNull();
        }
    }
}
