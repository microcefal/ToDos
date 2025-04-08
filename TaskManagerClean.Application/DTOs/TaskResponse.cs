using TaskManagerClean.Domain.Enums;

namespace TaskManagerClean.DTOs
{
    public class TaskResponse
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? Deadline { get; set; }
        public EnumTaskStatus Status { get; set; }
    }
}
