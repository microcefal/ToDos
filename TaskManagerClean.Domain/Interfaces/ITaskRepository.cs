using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Domain.Enums;
using TaskManagerClean.Domain.Models;

namespace TaskManagerClean.Domain.Data
{
    public interface ITaskRepository
    {
        Task<TodoTask> GetByIdAsync(Guid id);
        Task<IEnumerable<TodoTask>> GetAllAsync();
        Task CreateAsync(TodoTask task);
        Task UpdateAsync(Guid id, TodoTask task);
        Task UpdateStatusAsync(Guid taskId, EnumTaskStatus newStatus);
        Task DeleteAsync(Guid id);

        Task<IEnumerable<TodoTask>> GetByStatusAsync(EnumTaskStatus status);    
    }
}
