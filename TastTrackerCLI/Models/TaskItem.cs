namespace TaskTrackerCLI.Models
{
    public enum Status { done, todo, inProgress }
    public class TaskItem
    {
        public int Id { get; set; }
        public string About { get; set; }
        public Status Status { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }

    }
}
