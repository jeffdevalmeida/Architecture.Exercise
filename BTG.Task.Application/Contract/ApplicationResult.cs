using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTG.Task.Application.Contract
{
    public class ApplicationResult()
    {
        [JsonIgnore]
        public bool IsValid
        {
            get
            {
                return Errors.Count == 0;
            }
        }
        [JsonIgnore]
        public List<string> Errors { get; set; } = [];
    }
}
