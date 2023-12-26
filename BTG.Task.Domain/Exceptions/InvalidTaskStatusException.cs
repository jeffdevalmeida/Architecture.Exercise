using BTG.Task.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Exceptions
{
    public class InvalidTaskStatusException : Exception
    {
        public InvalidTaskStatusException(string message) : base(message) { }

        public static void ThrowIfInvalid(string status)
        {
            bool isValidStatus = Enum.TryParse(typeof(ETaskStatus), status, out object? _);
            if (!isValidStatus) throw new InvalidTaskStatusException($"<{status}> is invalid option. Try acceptable values: {string.Join(", ", Enum.GetNames(typeof(ETaskStatus)))}");
        }
    }
}
