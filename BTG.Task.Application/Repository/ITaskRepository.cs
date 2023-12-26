using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application.Repository
{
    public interface ITaskRepository : IReadWriteRepository<TaskAssignment>
    {
        Task<IEnumerable<TaskAssignment>> GetActiveByAuthorAsync(string author);
        Task<IEnumerable<TaskAssignment>> GetByStatus(ETaskStatus status);
    }
}
