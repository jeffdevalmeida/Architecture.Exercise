using BTG.Task.Application.Contract;
using BTG.Task.Application.DTOs;
using BTG.Task.Application.Extensions;
using BTG.Task.Application.Repository;
using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Enums;
using BTG.Task.Domain.Exceptions;
using BTG.Task.Domain.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application
{
    public class TaskApplication(ITaskRepository repository) : ITaskApplication
    {
        private readonly ITaskRepository _repository = repository;
        private readonly TaskAssignmentService _taskService = new();

        public async Task<SingleResult<TaskAssignmentDTO>> CreateAsync(TaskAssignmentCreateDTO task)
        {
            SingleResult<TaskAssignmentDTO> result = new(default);

            try
            {
                TaskAssignment domainTask = _taskService.Create(task.Title, task.Responsible, task.DeadLine);
                await _repository.SaveAsync(domainTask);
                result.Value = domainTask.ToContract();
            }
            catch (InvalidTaskStateException ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        public async Task<SingleResult<TaskAssignmentDeletionDTO>> DeleteAsync(Guid id)
        {
            SingleResult<TaskAssignmentDeletionDTO> result = new(default);

            TaskAssignment? task = await _repository.GetAsync(id);
            
            if (task is not null)
            {
                await _repository.DeleteAsync(id);
                result.Value = new("Task successfully deleted");
                return result;
            }

            result.Errors.Add($"Task {id} not found.");
            return result;
        }

        public async Task<CollectionResult<TaskAssignmentDTO>> GetActiveByAuthorAsync(string author)
        {
            IEnumerable<TaskAssignment> response = await _repository.GetActiveByAuthorAsync(author);
            return new CollectionResult<TaskAssignmentDTO>(response.ToContract());
        }

        public async Task<SingleResult<TaskAssignmentDTO?>> GetAsync(Guid id)
        {
            TaskAssignment? persistedTask = await _repository.GetAsync(id);
            return new SingleResult<TaskAssignmentDTO?>(persistedTask?.ToContract());
        }

        public async Task<CollectionResult<TaskAssignmentDTO>> GetByStatus(string status)
        {
            CollectionResult<TaskAssignmentDTO> result = new();
            try
            {
                InvalidTaskStatusException.ThrowIfInvalid(status);
                ETaskStatus enumStatus = (ETaskStatus)Enum.Parse(typeof(ETaskStatus), status);
                IEnumerable<TaskAssignment> response = await _repository.GetByStatus(enumStatus);
                return new CollectionResult<TaskAssignmentDTO>(response.ToContract());
            }
            catch (InvalidTaskStatusException ex)
            {
                result.Errors.Add(ex.Message);
            }
            return result;
        }

        public async Task<SingleResult<TaskAssignmentDTO>> UpdateAsync(Guid id, TaskAssignmentUpdateDTO task)
        {
            SingleResult<TaskAssignmentDTO> result = new(default);

            TaskAssignment? persistedTask = await _repository.GetAsync(id);

            if (persistedTask is null)
            {
                result.Errors.Add("Task not found");
                return result;
            }

            try
            {
                VerifyStatusChangedAndMerge(ref persistedTask, task);
                await _repository.SaveAsync(persistedTask);
                result.Value = persistedTask.ToContract();
            }
            catch(Exception ex)
            {
                result.Errors.Add(ex.Message);
            }

            return result;
        }

        private void VerifyStatusChangedAndMerge(ref TaskAssignment oldTask, TaskAssignmentUpdateDTO newTaskMap)
        {
            InvalidTaskStatusException.ThrowIfInvalid(newTaskMap.Status);
            ETaskStatus newStatus = (ETaskStatus)Enum.Parse(typeof(ETaskStatus), newTaskMap.Status);

            if (newStatus != oldTask.Status)
                _taskService.ChangeStatus(oldTask, newStatus);

            oldTask.Merge(newTaskMap);
            oldTask.UpdatedAt = DateTime.UtcNow;
        }
    }
}
