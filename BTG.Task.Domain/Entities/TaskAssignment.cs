using BTG.Task.Domain.Enums;
using System.Text.Json.Serialization;

namespace BTG.Task.Domain.Entities
{
    public class TaskAssignment(string title, string responsible, DateTime? deadLine) : Entity()
    {
        [JsonPropertyName("title")]
        public string Title { get; set; } = title;
        [JsonPropertyName("responsible")]
        public string Responsible { get; set; } = responsible;
        [JsonPropertyName("deadLine")]
        public DateTime? DeadLine { get; set; } = deadLine;
        [JsonPropertyName("status")]
        public ETaskStatus Status { get; set; } = ETaskStatus.New;
        [JsonPropertyName("completedOn")]
        public DateTime? CompletedOn { get; set; }
    }
}
