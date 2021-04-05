using FluentValidation;
using InfoTrace.API.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InfoTrace.API.Validations
{
    public class BingTraceCommandValidation : AbstractValidator<BingTraceCommand>
    {
        public BingTraceCommandValidation()
        {
            RuleFor(x => x.keyword).NotEmpty().NotNull();
            RuleFor(x => x.site).NotEmpty().NotNull();
        }
    }
}
