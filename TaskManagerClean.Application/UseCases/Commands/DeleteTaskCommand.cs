
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagerClean.Application.UseCases.Commands
{
    public class DeleteTaskCommand
    {
        public Guid Id { get; }


        public DeleteTaskCommand(Guid id)
        {
            Id = id;
        }
    }
}
