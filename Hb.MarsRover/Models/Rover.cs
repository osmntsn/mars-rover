using Hb.MarsRover.Commands;
using Hb.MarsRover.Exceptions;
using Hb.MarsRover.Validators;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Models
{
    public class Rover
    {
        private RoverState _state;
        private readonly IEnumerable<IRoverCommand> _commands;

        public Rover(RoverState initialState, IEnumerable<IRoverCommand> commands)
        {
            _state = initialState;
            _commands = commands;
        }

        public RoverState ExecuteCommand(IRoverCommand command, Plateau plateau)
        {
            RoverStateValidator roverStateValidator = new RoverStateValidator(plateau);
            var commandState = command.ExecuteCommand(_state);

            var validationResult = roverStateValidator.Validate(_state);

            if (!validationResult.IsValid)
            {
                throw new CommandOutOfBoundsException($"An error occuured while executing command \"{command.CommandName}\". Unable to move to location {commandState.PrintState} from {_state.PrintState} because its out of plateu bounds");
            }

            _state = commandState;
            return _state;
        }

        public RoverState GetState()
        {
            return _state;
        }


        public IEnumerable<IRoverCommand> GetRoverCommands()
        {
            return _commands;
        }
    }
}
