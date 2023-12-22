using BTG.Task.Application.Repository;
using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Infrastructure.DataAccess.DynamoDB.Repository
{
    internal class TaskRepository : ITaskRepository
    {
        public System.Threading.Tasks.Task DeleteAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskAssignment>> GetActiveByAuthorAsync(Guid id, string author)
        {
            throw new NotImplementedException();
        }

        public Task<TaskAssignment?> GetAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<TaskAssignment>> GetByStatus(ETaskStatus status)
        {
            throw new NotImplementedException();
        }

        public Task<TaskAssignment> SaveAsync(TaskAssignment model)
        {
            throw new NotImplementedException();
        }
    }
}
