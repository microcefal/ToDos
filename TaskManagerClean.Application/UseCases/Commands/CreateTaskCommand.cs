
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Domain.Models;

namespace TaskManagerClean.Application.UseCases.Commands
{
    public class CreateTaskCommand
    {
        public string Title { get; }
        public string Description { get; }
        public DateTime? Deadline { get; }

        public CreateTaskCommand(string title, string description, DateTime? deadline)
        {
            Title = title;
            Description = description;
            Deadline = deadline;
        }
}
    }
    
