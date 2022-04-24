using Hb.MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Commands
{
    public class RCommand : IRoverCommand
    {
        public string CommandName => "R";
        public RoverState ExecuteCommand(RoverState position)
        {
            var direction = position.Direction;
            switch (direction)
            {
                case Direction.N: position.Direction = Direction.E; break;
                case Direction.W: position.Direction = Direction.N; break;
                case Direction.S: position.Direction = Direction.W; break;
                case Direction.E: position.Direction = Direction.S; break;
            }
            return position;
        }
    }
}
