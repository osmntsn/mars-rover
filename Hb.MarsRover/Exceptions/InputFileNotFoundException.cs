using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Exceptions
{
    public class InputFileNotFoundException : Exception
    {
        public InputFileNotFoundException()
          : base("input.txt not found in working directory")
        {

        }

    }
}
