using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Exceptions
{
    public class InvalidTaskStateException : Exception
    {
        private const string c_internal_message = "The task has invalid values for the current state";
        public InvalidTaskStateException() : base(c_internal_message) { }
        public InvalidTaskStateException(Exception? innerException) : base(c_internal_message, innerException) { }
    }
}
