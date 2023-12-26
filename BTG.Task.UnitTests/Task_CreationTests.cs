using BTG.Task.Domain.Entities;
using BTG.Task.Domain.Exceptions;
using BTG.Task.Domain.Services;

namespace BTG.Task.UnitTests
{
    public class Task_CreationTests
    {
        [Theory]
        [InlineData("", "")]
        [InlineData(null, null)]
        [InlineData("", null)]
        [InlineData(null, "")]
        public void TaskAssignment_ShouldntCreateWhenTitleAndResponsibleIsNullOrEmpty_ReturnException(string title, string responsible)
        {
            DateTime deadLine = DateTime.UtcNow.AddDays(1);
            TaskAssignmentService taskAssignmentService = new();

            Assert.Throws<InvalidTaskStateException>(() => taskAssignmentService.Create(title, responsible, deadLine));
        }

        [Theory]
        [InlineData("Gerar backup", "John Doe", "2023-12-30T00:56:04Z")]
        [InlineData("Mobile apps", "John Doe", "2023-12-10T00:56:04Z")]
        public void TaskAssignment_CreationSuccessfullWithAllFieldsFilled_ReturnTrue(string title, string responsible, DateTime deadLine)
        {
            TaskAssignmentService taskAssignmentService = new();
            TaskAssignment task = taskAssignmentService.Create(title, responsible, deadLine);
            Assert.True(task is not null && task.Id is not null);
        }

        [Theory]
        [InlineData("Gerar backup", "John Doe", "2023-12-30T00:56:04Z")]
        [InlineData("Mobile apps", "John Doe", "2023-12-10T00:56:04Z")]
        public void TaskAssignment_WhenCreateTaskAuditableFieldsMustBeFullfilled_ReturnTrue(string title, string responsible, DateTime deadLine)
        {
            TaskAssignmentService taskAssignmentService = new();
            TaskAssignment task = taskAssignmentService.Create(title, responsible, deadLine);
            Assert.True(task.CreatedAt <= DateTime.UtcNow && task.UpdatedAt is null);
        }

        [Fact]
        public void TaskAssignment_WhenCreateTaskStatusMustBeNew_ReturnTrue()
        {
            string title = "New task";
            string responsible = "John Doe";
            DateTime deadLine = DateTime.UtcNow.AddDays(1);

            TaskAssignmentService taskAssignmentService = new();
            TaskAssignment task = taskAssignmentService.Create(title, responsible, deadLine);
            Assert.True(task.Status == Domain.Enums.ETaskStatus.New);
        }
    }
}