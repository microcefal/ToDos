using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Domain.Enums;

namespace TaskManagerClean.Domain.Models
{
    public class TodoTask
    {
        [Key] // Указываем первичный ключ
        public Guid Id { get; private set; }

        public string Title { get; private set; }
        public string Description { get; private set; }
        public DateTime? Deadline { get; private set; }
        public EnumTaskStatus Status { get; set; }

        private TodoTask() { } // Конструктор для EF Core

        public TodoTask(Guid id, string title, string description, DateTime? deadline, EnumTaskStatus status)
        {
            Id = id;
            Title = title;
            Description = description;
            Deadline = deadline;
            Status = status;
        }
        //public Guid Id => _id;
        //public string Title => _title;
        //public string Description => _description;  
    }
}
