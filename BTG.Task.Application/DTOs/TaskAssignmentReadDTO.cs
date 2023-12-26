using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BTG.Task.Application.DTOs
{
    public record TaskAssignmentDTO(string Id, string Title, string Responsible, DateTime? DeadLine, string Status, DateTime? CompletedOn, DateTime CreatedAt, DateTime? UpdatedAt);
    public record TaskAssignmentDeletionDTO(string Message);
}
