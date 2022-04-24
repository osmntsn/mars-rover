using Hb.MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Commands
{

    public class LCommand : IRoverCommand
    {
        public string CommandName => "L";

        public RoverState ExecuteCommand(RoverState position)
        {
            var direction = position.Direction;
            switch (direction)
            {
                case Direction.N: position.Direction = Direction.W; break;
                case Direction.W: position.Direction = Direction.S; break;
                case Direction.S: position.Direction = Direction.E; break;
                case Direction.E: position.Direction = Direction.N; break;
            }
            return position;
        }
    }
}
