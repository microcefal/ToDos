
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Domain.Models;

namespace TaskManagerClean.Application.UseCases.Commands
{
    public class GetTaskCommand
    {
        public Guid Id { get; }

        public GetTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
