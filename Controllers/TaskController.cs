using Microsoft.AspNetCore.Mvc;
using System.Runtime.CompilerServices;
using TaskManagerClean.Application.Services;
using TaskManagerClean.Domain.Models;
using TaskManagerClean.DTOs;

namespace TaskManagerClean.Controllers
{
    [ApiController]
    [Route("api/tasks")]
    public class TaskController : ControllerBase
    {
        private readonly TaskService _taskService;

        public TaskController(TaskService taskService)
        {
            _taskService = taskService;
        }
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateTaskDetalis(Guid id, [FromBody] CreateTaskRequest taskRequest)
        {
            await _taskService.UpdateTask(taskRequest.Title, taskRequest.Description, id);
            return NoContent();
        }
        [HttpGet("{id}")]
        public async Task<ActionResult<TaskResponse>> GetTaskById(Guid id)
        {
            var task = await _taskService.GetTaskById(id);
            if (task == null) return NotFound();
            return Ok(new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                Description = task.Description,
                Deadline = task.Deadline,
                Status = task.Status
            });
        }
        [HttpGet]
        public async Task<ActionResult<List<TaskResponse>>> GetAllTask()
        {
            var tasks = await _taskService.GetAllTask();
            return Ok(tasks);
        }
        [HttpPost]
        public async Task<IActionResult> CreateTask([FromBody] CreateTaskRequest taskRequest)
        {
            var createdTask = await _taskService.CreateTask(taskRequest.Title, taskRequest.Description, taskRequest.Deadline);

            return CreatedAtAction(nameof(GetTaskById), new { id = createdTask.Id }, createdTask);
        }
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteTask(Guid id)
        {
            await _taskService.DeleteTask(id);
            return NoContent();
        }

    }
}
