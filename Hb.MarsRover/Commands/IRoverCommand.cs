using Hb.MarsRover.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Commands
{

    public interface IRoverCommand 
    {
        string CommandName { get; }
        RoverState ExecuteCommand(RoverState position);
    }
}
