using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Domain.Services
{
    internal class TaskBuilder
    {
        private TaskAssignment _model;

        public TaskBuilder(string title, string author, DateTime? dueDate)
        {
            _model = new(title, author, dueDate);
        }

        internal TaskAssignment Build()
        {
            if (_model.DeadLine is null || _model.DeadLine < DateTime.UtcNow) // DeadLine shouldnt be less than now
                _model.DeadLine = GetDefaultDeadLine();

            if (string.IsNullOrEmpty(_model.Title) || string.IsNullOrEmpty(_model.Responsible))
                throw new InvalidTaskStateException();

            return _model;
        }

        private static DateTime GetDefaultDeadLine() => DateTime.UtcNow.AddDays(1);
    }
}
