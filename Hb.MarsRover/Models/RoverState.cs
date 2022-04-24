using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Models
{
    public struct RoverState
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        public string PrintState()
        {
            return $"{X} {Y} {Direction}";
        }
    }
}
