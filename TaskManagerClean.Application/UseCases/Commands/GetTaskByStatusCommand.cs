
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerClean.Domain.Enums;
using TaskManagerClean.Domain.Models;

namespace TaskManagerClean.Application.UseCases.Commands
{
    public class GetTaskByStatusCommand
    {
        public EnumTaskStatus NewStatus {  get;}

        public GetTaskByStatusCommand(EnumTaskStatus newStatus)
        {
            NewStatus = newStatus;
        }
    }
}
