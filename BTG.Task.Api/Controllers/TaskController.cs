using BTG.Task.Application;
using BTG.Task.Application.Contract;
using BTG.Task.Application.DTOs;
using BTG.Task.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace BTG.Task.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TaskController : ControllerBase
    {
        private readonly ILogger<TaskController> _logger;
        private readonly ITaskApplication _taskApplication;

        public TaskController(ILogger<TaskController> logger, ITaskApplication taskApplication)
        {
            _logger = logger;
            _taskApplication = taskApplication;
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<TaskAssignmentDTO?>> GetAsync(Guid id)
        {
            SingleResult<TaskAssignmentDTO?> result = await _taskApplication.GetAsync(id);
            if (result.Value is null)
                return NotFound();

            return result.Value;
        }

        [HttpGet("actives")]
        public async Task<IActionResult> GetActivesByAuthor([Required] string author)
        {
            CollectionResult<TaskAssignmentDTO> activeTasks = await _taskApplication.GetActiveByAuthorAsync(author);
            return ProducesResponse(activeTasks);
        }

        [HttpGet]
        public async Task<IActionResult> GetByStatus([Required] string status)
        {
            CollectionResult<TaskAssignmentDTO> activeTasks = await _taskApplication.GetByStatus(status);
            return ProducesResponse(activeTasks);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] TaskAssignmentCreateDTO task)
        {
            SingleResult<TaskAssignmentDTO> result = await _taskApplication.CreateAsync(task);
            return ProducesResponse(result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync(Guid id, [FromBody] TaskAssignmentUpdateDTO task)
        {
            SingleResult<TaskAssignmentDTO> result = await _taskApplication.UpdateAsync(id, task);
            return ProducesResponse(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAsync(Guid id)
        {
            SingleResult<TaskAssignmentDeletionDTO> result = await _taskApplication.DeleteAsync(id);
            return ProducesResponse(result);
        }

        private IActionResult ProducesResponse(ApplicationResult result)
        {
            if (!result.IsValid)
            {
                foreach (string error in result.Errors)
                    ModelState.AddModelError("errors", error);

                return BadRequest(ModelState);
            }

            return Ok(result);
        }
    }
}
