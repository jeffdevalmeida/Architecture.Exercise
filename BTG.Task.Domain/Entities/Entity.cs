using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Entities
{
    public abstract class Entity : AuditableEntity, IAggregator
    {
        protected Entity() : base()
        {
            Id = Guid.NewGuid().ToString();
        }

        [JsonPropertyName("pk")]
        public string Pk => Id;
        [JsonPropertyName("sk")]
        public string Sk => Pk;
        [JsonPropertyName("id")]
        public string Id { get; set; }
    }
}
