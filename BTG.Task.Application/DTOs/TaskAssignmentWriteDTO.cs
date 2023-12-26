using BTG.Task.Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BTG.Task.Application.DTOs
{
    public record TaskAssignmentCreateDTO([Required] string Title, [Required] string Responsible, [Required] DateTime? DeadLine);
    public record TaskAssignmentUpdateDTO([Required] string Title, [Required] string Responsible, [Required] DateTime? DeadLine, [Required] string Status);
}
