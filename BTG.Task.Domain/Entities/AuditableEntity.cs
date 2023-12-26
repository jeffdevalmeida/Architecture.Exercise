using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Entities
{
    public abstract class AuditableEntity
    {
        public AuditableEntity()
        {
            CreatedAt = DateTime.UtcNow;
        }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }
        [JsonPropertyName("updatedAt")]
        public DateTime? UpdatedAt { get; set; }
    }
}
