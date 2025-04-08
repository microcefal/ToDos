
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
    public class GetTaskByIdHandler 
    {
        private readonly ITaskRepository _taskRepository;
        public GetTaskByIdHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<TodoTask> Handle(GetTaskCommand command)
        {
            var task = await _taskRepository.GetByIdAsync(command.Id);
            if (task == null) throw new Exception("Task not found");
            return task;

        }
    }
}
