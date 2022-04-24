using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hb.MarsRover.Exceptions
{
    public class InputFileValidationException : Exception
    {
        public InputFileValidationException(string message)
            : base(message)
        {

        }
    }
}
