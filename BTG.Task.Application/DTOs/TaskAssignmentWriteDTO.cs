using BTG.Task.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application.DTOs
{
    public record TaskAssignmentCreateDTO(string Title, string Responsible, DateTime DeadLine);
    public record TaskAssignmentUpdateDTO(string Title, string Responsible, DateTime DeadLine, ETaskStatus Status);
}
