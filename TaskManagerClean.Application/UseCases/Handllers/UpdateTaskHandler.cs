
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Application.UseCases.Commands;
using TaskManagerClean.Domain.Data;
using TaskManagerClean.Domain.Enums;
using TaskManagerClean.Domain.Models;

namespace TaskManagerClean.Application.UseCases.Handllers
{
    public class UpdateTaskHandler 
    {
        private readonly ITaskRepository _taskRepository;
        public UpdateTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task Handle(UpdateTaskStatusCommand command)
        {
            var task = await _taskRepository.GetByIdAsync(command.Id);
            if (task == null) throw new Exception("Task now found");

            var updateTask = new TodoTask(
                task.Id, 
                task.Title, 
                task.Description,
                task.Deadline, 
                command.NewStatus); 

            await _taskRepository.UpdateAsync(command.Id, updateTask);
        }
    }
}
