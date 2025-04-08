namespace TaskManagerClean.DTOs
{
    public class CreateTaskRequest
    {
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        public DateTime? Deadline { get; set; }

        public CreateTaskRequest() { } // 🔹 Конструктор нужен для сериализации
    }
}
