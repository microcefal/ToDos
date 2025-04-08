
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Application.UseCases.Commands;
using TaskManagerClean.Domain.Data;

namespace TaskManagerClean.Application.UseCases.Handllers
{
    public class DeleteTaskHandler 
    {
        private readonly ITaskRepository _taskRepository;
        public DeleteTaskHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<bool> Handle(DeleteTaskCommand command)
        {
            var task = await _taskRepository.GetByIdAsync(command.Id);
            if (task == null) throw new KeyNotFoundException($"Task with ID {command.Id} not found.");
            await _taskRepository.DeleteAsync(command.Id);
            return true;
        }
    }
}
