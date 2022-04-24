using Hb.MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Commands
{
    public class MCommand : IRoverCommand
    {
        public string CommandName => "M";
        public RoverState ExecuteCommand(RoverState position)
        {
            var direction = position.Direction;
            switch (direction)
            {
                case Direction.N: position.Y++; break;
                case Direction.W: position.X--; break;
                case Direction.S: position.Y--; break;
                case Direction.E: position.X++; break;
            }
            return position;
        }
    }
}
