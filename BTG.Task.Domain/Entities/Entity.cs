using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Entities
{
    public abstract class Entity : AuditableEntity, IAggregator
    {
        protected Entity() : base()
        {
            Id = Guid.NewGuid();
        }

        public Guid Id { get; }
    }
}
