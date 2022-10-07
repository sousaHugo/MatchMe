using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MatchMe.Common.Shared.FluentValidation
{
    public abstract class Validator<T> : AbstractValidator<T>
    {
        public Validator()
        {
            RuleLevelCascadeMode = CascadeMode.Stop;
        }
    }
}
