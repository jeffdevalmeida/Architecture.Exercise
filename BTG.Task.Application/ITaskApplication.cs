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
        Task<SingleResult<TaskAssignmentDTO>> CreateAsync(TaskAssignmentCreateDTO task);
        Task<SingleResult<TaskAssignmentDTO>> UpdateAsync(Guid id, TaskAssignmentUpdateDTO task);
        Task<SingleResult<TaskAssignmentDeletionDTO>> DeleteAsync(Guid id);
        Task<SingleResult<TaskAssignmentDTO?>> GetAsync(Guid id);
        Task<CollectionResult<TaskAssignmentDTO>> GetActiveByAuthorAsync(string author);
        Task<CollectionResult<TaskAssignmentDTO>> GetByStatus(string status);
    }
}
