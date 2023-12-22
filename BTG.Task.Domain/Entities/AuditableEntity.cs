using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public AuditableEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        public DateTime CreatedAt { get; }
        public DateTime? UpdatedAt { get; set; }
    }
}
