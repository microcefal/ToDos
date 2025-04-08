using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Application.UseCases.Commands;
using TaskManagerClean.Application.UseCases.Handllers;
using TaskManagerClean.Domain.Enums;
using TaskManagerClean.Domain.Models;
using TaskManagerClean.DTOs;

namespace TaskManagerClean.Application.Services
{
    public class TaskService 
    {
        private readonly UpdateTaskHandler _UpstatusHandler;
        private readonly UpdateDetalisTaskHandler _UpDetalisTaskHandler;
        private readonly CreateTaskHandler _CreateTaskHandler;
        private readonly DeleteTaskHandler _DeleteTaskHandler;
        private readonly GetTaskByIdHandler _GetTaskByIdHandler;
        private readonly GetTaskByStatusHandler _GetTaskByStatusHandler;
        private readonly GetAllTaskHandler _GetAllTaskHandler;

        public TaskService(
            GetAllTaskHandler GetAllTaskHandler,
            UpdateDetalisTaskHandler updateDetalisTaskHandler,
            UpdateTaskHandler updateTaskHandler, 
            DeleteTaskHandler deleteTaskHandler,
            GetTaskByStatusHandler getTaskByStatusHandler,
            GetTaskByIdHandler getTaskByIdHandler,
            CreateTaskHandler createTaskHandler)
        {
            _GetAllTaskHandler = GetAllTaskHandler;
            _CreateTaskHandler = createTaskHandler;
            _DeleteTaskHandler = deleteTaskHandler;
            _GetTaskByIdHandler = getTaskByIdHandler;
            _GetTaskByStatusHandler = getTaskByStatusHandler;
            _UpDetalisTaskHandler = updateDetalisTaskHandler;
            _UpstatusHandler = updateTaskHandler;
        }

        public async Task UpdateStatus(Guid id, EnumTaskStatus newStatus)
        {
            var command = new UpdateTaskStatusCommand(id, newStatus);
            await _UpstatusHandler.Handle(command);
        }

        public async Task DeleteTask(Guid id)
        {
            var command = new DeleteTaskCommand(id);
            await _DeleteTaskHandler.Handle(command);
        }
        public async Task<TodoTask> GetTaskById(Guid id)
        {
            var command = new GetTaskCommand(id);
            return await _GetTaskByIdHandler.Handle(command);
           
        }
        public async Task<List<TaskResponse>> GetAllTask()
        {
            return await _GetAllTaskHandler.Handle();
        }
        public async Task<IEnumerable<TodoTask>> GetTaskByStatus(EnumTaskStatus status)
        {
            var command = new GetTaskByStatusCommand( status);
            return  await _GetTaskByStatusHandler.Handle(command);
        }
        public async Task<TodoTask> CreateTask(string title, string description, DateTime? deadline)
        {
            var command = new CreateTaskCommand(title, description, deadline);
            return await _CreateTaskHandler.Handle(command);
            

        }
        public async Task UpdateTask(string title, string description, Guid id)
        {
            var command = new UpdateDetalisTaskCommand(title, description, id);
            await _UpDetalisTaskHandler.Handle(command);
        }

    }
}
