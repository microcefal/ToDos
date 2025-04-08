using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Domain.Data;
using TaskManagerClean.Domain.Enums;
using TaskManagerClean.Domain.Models;
using TaskManagerClean.Infrastructure.Data;

namespace TaskManagerClean.Persistence.Repositories
{
    public class TaskRepository : ITaskRepository
    {
       private readonly ApplicationDbContext _context;
        public TaskRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<TodoTask>> GetAllAsync()
        {
            return await _context.Tasks.ToListAsync();
        }
        public async Task<TodoTask> GetByIdAsync(Guid id)
        {
            return await _context.Tasks.FindAsync(id);
        }
        public async Task CreateAsync(TodoTask task)
        {
            await _context.Tasks.AddAsync(task);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateAsync(Guid id, TodoTask task)
        {
            var existingTask = await _context.Tasks.FindAsync(id);
          
            _context.Entry(existingTask).CurrentValues.SetValues(task);
            await _context.SaveChangesAsync();
        }
        public async Task UpdateStatusAsync(Guid taskId, EnumTaskStatus newStatus)
        {
            var task = await _context.Tasks.FindAsync(taskId);
            if (task == null) throw new Exception("Task not found");

            task.Status = newStatus;
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(Guid id)
        {
            var task = await _context.Tasks.FindAsync(id);      
            _context.Tasks.Remove(task);
            await _context.SaveChangesAsync();
        }
        public async Task<IEnumerable<TodoTask>> GetByStatusAsync(EnumTaskStatus status)
        {
            return await _context.Tasks.Where(t => t.Status == status).ToListAsync();
        }
    }
    }

