using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Exceptions
{
    public class InvalidChangedStateException : Exception
    {
        public InvalidChangedStateException(string message) : base(message) { }
        public InvalidChangedStateException(string message, Exception? innerException) : base(message, innerException) { }
    }
}
