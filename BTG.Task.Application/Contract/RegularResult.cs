using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application.Contract
{
    public class SingleResult<T>(T? data) : ApplicationResult
    {
        public T? Value { get; set; } = data;

    }
}
