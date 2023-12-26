using BTG.Task.Application.DTOs;
using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application.Extensions
{
    public static class TaskAssignDTOExtensions
    {
        public static TaskAssignmentDTO ToContract(this TaskAssignment entity)
        {
            return new TaskAssignmentDTO(entity.Id, entity.Title, entity.Responsible, entity.DeadLine, Enum.GetName(entity.Status)!, entity.CompletedOn, entity.CreatedAt, entity.UpdatedAt);
        }

        public static TaskAssignment ToEntity(this TaskAssignmentDTO dto)
        {
            return new TaskAssignment(dto.Title, dto.Responsible, dto.DeadLine)
            {
                Id = dto.Id,
                CompletedOn = dto.CompletedOn,
                CreatedAt = dto.CreatedAt,
                UpdatedAt = dto.UpdatedAt,
                Status = (ETaskStatus)Enum.Parse(typeof(ETaskStatus), dto.Status)
            };
        }

        public static IEnumerable<TaskAssignmentDTO> ToContract(this IEnumerable<TaskAssignment> entities)
        {
            List<TaskAssignmentDTO> result = [];
            foreach (var entity in entities)
                result.Add(new TaskAssignmentDTO(entity.Id, entity.Title, entity.Responsible, entity.DeadLine, Enum.GetName(entity.Status)!, entity.CompletedOn, entity.CreatedAt, entity.UpdatedAt));
            return result;
        }

        public static IEnumerable<TaskAssignment> ToEntity(this IEnumerable<TaskAssignment> dtos)
        {
            List<TaskAssignment> result = [];
            foreach(var dto in dtos)
            {
                result.Add(new TaskAssignment(dto.Title, dto.Responsible, dto.DeadLine)
                {
                    Id = dto.Id,
                    CompletedOn = dto.CompletedOn,
                    CreatedAt = dto.CreatedAt,
                    UpdatedAt = dto.UpdatedAt,
                    Status = (ETaskStatus)Enum.Parse(typeof(ETaskStatus), dto.Status.ToString())
                });
            }
            return result;
        }

        public static TaskAssignment Merge(this TaskAssignment task, TaskAssignmentUpdateDTO dto) // instead that can use auto mapper for best scenarios
        {
            task.Title = dto.Title;
            task.Responsible = dto.Responsible;
            task.DeadLine = dto.DeadLine;
            return task;
        }
    }
}
