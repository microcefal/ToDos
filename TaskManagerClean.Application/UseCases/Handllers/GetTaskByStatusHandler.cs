
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
    public class GetTaskByStatusHandler 
    {
        private readonly ITaskRepository _taskRepository;
        public GetTaskByStatusHandler(ITaskRepository taskRepository)
        {
            _taskRepository = taskRepository;
        }
        public async Task<IEnumerable<TodoTask>> Handle(GetTaskByStatusCommand command)
        {
           var tasks =  await _taskRepository.GetByStatusAsync(command.NewStatus);
            if (tasks == null || !tasks.Any()) throw new Exception("No tasks found with the specified status."); 
            return tasks;
        }
    }
}
