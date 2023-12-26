using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Infrastructure.Settings
{
    internal class DatabaseSettings
    {
        public const string KeyName = "Database";

        public string DynamoTableName { get; set; } = default!;
    }
}
