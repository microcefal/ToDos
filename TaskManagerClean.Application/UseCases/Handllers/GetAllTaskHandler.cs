using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Application.UseCases.Commands;
using TaskManagerClean.Domain.Data;
using TaskManagerClean.DTOs;

namespace TaskManagerClean.Application.UseCases.Handllers
{
    public class GetAllTaskHandler
    {
        private readonly ITaskRepository _taskRepository;
        public GetAllTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<List<TaskResponse>> Handle()
        {
            var tasks = await _taskRepository.GetAllAsync();
            return tasks.Select(task => new TaskResponse
            {
                Id = task.Id,
                Title = task.Title,
                Deadline = task.Deadline,
                Description = task.Description,
                Status = task.Status
            }).ToList();
        }
    }
}
