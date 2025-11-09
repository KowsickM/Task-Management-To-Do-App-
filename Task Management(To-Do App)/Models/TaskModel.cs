namespace Task_Management_To_Do_App_.Models
{
    public class TaskModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string? Description { get; set; }

        public TaskStatus Status { get; set; } = TaskStatus.Pending;

        public DateTime CreatedAt { get; set; } = DateTime.Now;
    }

    public enum TaskStatus
    {
        Pending,
        InProgress,
        Completed
    }
}