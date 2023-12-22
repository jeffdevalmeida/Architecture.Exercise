using BTG.Task.Application.Contract;
using BTG.Task.Application.DTOs;
using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application
{
    public interface ITaskApplication
    {
        Task<SingleResult<TaskAssignment>> CreateAsync(TaskAssignmentCreateDTO task);
        Task<SingleResult<TaskAssignment>> UpdateAsync(Guid id, TaskAssignmentUpdateDTO task);
        Task<SingleResult<TaskAssignmentDeletionDTO>> DeleteAsync(Guid id);
        Task<SingleResult<TaskAssignment?>> GetAsync(Guid id);
        Task<CollectionResult<TaskAssignment>> GetActiveByAuthorAsync(Guid id, string author);
        Task<CollectionResult<TaskAssignment>> GetByStatus(ETaskStatus status);
    }
}
