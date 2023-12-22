using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application.Contract
{
    public class CollectionResult<T> : ApplicationResult
    {
        public int Count => Data.Count();
        public IEnumerable<T> Data { get; set; }

        public CollectionResult()
        {
            Data = [];
        }

        public CollectionResult(IEnumerable<T> data)
        {
            Data = data;
        }
    }
}
