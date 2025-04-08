
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Application.UseCases.Commands;
using TaskManagerClean.Domain.Data;
using TaskManagerClean.Domain.Enums;
using TaskManagerClean.Domain.Models;

namespace TaskManagerClean.Application.UseCases.Handllers
{
    public class CreateTaskHandler  
    {
        private readonly ITaskRepository _repository;

        public CreateTaskHandler(ITaskRepository repository)
        {
            _repository = repository;
        }

        public async Task<TodoTask> Handle(CreateTaskCommand command)
        {
            if (string.IsNullOrWhiteSpace(command.Title))
                throw new ArgumentException("Title cannot be empty.");

            if (command.Deadline.HasValue && command.Deadline.Value < DateTime.UtcNow)
                throw new ArgumentException("Deadline cannot be in the past.");

            var task = new TodoTask(
                Guid.NewGuid(), 
                command.Title, 
                command.Description, 
                command.Deadline, 
                EnumTaskStatus.Новый);

            await _repository.CreateAsync(task);
            return task;
        }
    }
}
