using Hb.MarsRover.Commands;
using Hb.MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Exceptions
{
    public class CommandOutOfBoundsException : Exception
    {
        public CommandOutOfBoundsException(string message)
            : base(message)
        {

        }
    }
}
