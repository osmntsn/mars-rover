using FluentValidation;
using Hb.MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Validators
{
    public class RoverStateValidator : AbstractValidator<RoverState>
    {
        public RoverStateValidator(Plateau plateau)
        {
            RuleFor(state => state.X).GreaterThanOrEqualTo(0).LessThanOrEqualTo(plateau.X);
            RuleFor(state => state.Y).GreaterThanOrEqualTo(0).LessThanOrEqualTo(plateau.Y);
        }
    }
}
