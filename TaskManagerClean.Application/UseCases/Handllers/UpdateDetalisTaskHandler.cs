using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Application.UseCases.Commands;
using TaskManagerClean.Domain.Data;
using TaskManagerClean.Domain.Models;

namespace TaskManagerClean.Application.UseCases.Handllers
{
    public class UpdateDetalisTaskHandler
    {
        private readonly ITaskRepository _taskRepository;
        public UpdateDetalisTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }   
        public async Task Handle(UpdateDetalisTaskCommand command)
        {
            var task = await _taskRepository.GetByIdAsync(command.Id);
            if (task == null) throw new KeyNotFoundException("Task not found");
            var updateTask = new TodoTask(
                task.Id,
                command.Description,
                command.Title,
                task.Deadline,
                task.Status
                );

            await _taskRepository.UpdateAsync(command.Id, updateTask);
        }
    }
}
