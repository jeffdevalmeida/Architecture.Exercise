using BTG.Task.Domain.Enums;

namespace BTG.Task.Domain.Entities
{
    public class TaskAssignment(string title, string responsible, DateTime deadLine) : Entity()
    {
        public string Title { get; set; } = title;
        public string Responsible { get; set; } = responsible;
        public DateTime DeadLine { get; set; } = deadLine;
        public ETaskStatus Status { get; internal set; } = ETaskStatus.New;
        public DateTime? CompletedOn { get; internal set; }
    }
}
