using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Enums;
using BTG.Task.Domain.Exceptions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Services
{
    public sealed class TaskAssignmentService
    {
        public TaskAssignment Create(string title, string responsible, DateTime deadLine)
        {
            TaskBuilder builder = new(title, responsible, deadLine);
            TaskAssignment task = builder.Build();

            return task;
        }

        public TaskAssignment ChangeStatus(TaskAssignment task, ETaskStatus newStatus)
        {
            if (newStatus == ETaskStatus.Closed) return CloseTask(task);

            if (task.Status == ETaskStatus.New && newStatus == ETaskStatus.Resolved)
                throw new InvalidChangedStateException($"Task {task.Id} cannot be changed to Resolved without being activated", new());
            task.Status = newStatus;

            return task;
        }

        public TaskAssignment CloseTask(TaskAssignment task)
        {
            task.CompletedOn = DateTime.UtcNow;
            return task;
        }
    }
}
