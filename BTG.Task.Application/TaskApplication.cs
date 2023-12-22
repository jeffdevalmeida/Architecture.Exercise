using BTG.Task.Application.Contract;
using BTG.Task.Application.DTOs;
using BTG.Task.Application.Repository;
using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Enums;
using BTG.Task.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application
{
    public class TaskApplication(ITaskRepository repository, TaskAssignmentService taskService) : ITaskApplication
    {
        private readonly ITaskRepository _repository = repository;
        private readonly TaskAssignmentService _taskService = taskService;

        public async Task<SingleResult<TaskAssignment>> CreateAsync(TaskAssignmentCreateDTO task)
        {
            // Add validator
            TaskAssignment domainTask = _taskService.Create(task.Title, task.Responsible, task.DeadLine);
            await _repository.SaveAsync(domainTask);

            return new SingleResult<TaskAssignment>(domainTask);
        }

        public async Task<SingleResult<TaskAssignmentDeletionDTO>> DeleteAsync(Guid id)
        {
            await _repository.DeleteAsync(id);
            return new SingleResult<TaskAssignmentDeletionDTO>(new("Task successfully deleted"));
        }

        public async Task<CollectionResult<TaskAssignment>> GetActiveByAuthorAsync(Guid id, string author)
        {
            IEnumerable<TaskAssignment> response = await _repository.GetActiveByAuthorAsync(id, author);
            return new CollectionResult<TaskAssignment>(response);
        }

        public async Task<SingleResult<TaskAssignment?>> GetAsync(Guid id)
        {
            TaskAssignment? persistedTask = await _repository.GetAsync(id);
            return new SingleResult<TaskAssignment?>(persistedTask);
        }

        public async Task<CollectionResult<TaskAssignment>> GetByStatus(ETaskStatus status)
        {
            IEnumerable<TaskAssignment> response = await _repository.GetByStatus(status);
            return new CollectionResult<TaskAssignment>(response);
        }

        public async Task<SingleResult<TaskAssignment>> UpdateAsync(Guid id, TaskAssignmentUpdateDTO task)
        {
            SingleResult<TaskAssignment> result = new(default);

            TaskAssignment? persistedTask = await _repository.GetAsync(id);

            if (persistedTask is null)
            {
                result.Errors.Add("Task not found");
                return result;
            }

            try
            {
                VerifyStatusChanged(ref persistedTask, task);
                await _repository.SaveAsync(persistedTask);
                result.Value = persistedTask;
            }
            catch(Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        private void VerifyStatusChanged(ref TaskAssignment oldTask, TaskAssignmentUpdateDTO newTaskMap)
        {
            if (newTaskMap.Status != oldTask.Status)
            {
                _taskService.ChangeStatus(oldTask, newTaskMap.Status);
            }
        }
    }
}
