
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Domain.Enums;

namespace TaskManagerClean.Application.UseCases.Commands
{
    public class UpdateTaskStatusCommand
    {
        public Guid Id { get; }
        public EnumTaskStatus NewStatus { get; }

        public UpdateTaskStatusCommand(Guid id, EnumTaskStatus newstatus)
        {
            Id = id;
            NewStatus = newstatus;
        }
    }
}
