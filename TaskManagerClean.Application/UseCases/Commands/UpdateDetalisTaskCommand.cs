using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerClean.Application.UseCases.Commands
{
   public class UpdateDetalisTaskCommand
    {
        public string Title { get; }
        public string Description { get; }
        public Guid Id { get; }

        public UpdateDetalisTaskCommand(string title, string description, Guid id)
        {
            Title = title;
            Description = description;
            Id = id;
        }
    }
}
