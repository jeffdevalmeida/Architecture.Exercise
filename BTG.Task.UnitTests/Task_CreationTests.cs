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
    }
}