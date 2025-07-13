namespace CompleteProject.Models
{
    public abstract class TodoItem
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Description { get; set; } = "";
        public int? ParentId { get; set; }
        public bool IsCompleted { get; set; }
    }

    public class Bug : TodoItem
    {
        public string AffectedVersion { get; set; } = "";
        public int AffectedUsers { get; set; }
        public string Severity { get; set; } = "Medium";
        public string? ScreenshotUrl { get; set; }
        public int? AttachedBugId { get; set; }
        public Bug? AttachedBug { get; set; }
    }

    public class Feature : TodoItem
    {
        public DateTime? DueDate { get; set; }
        public int? AttachedFeatureId { get; set; }
        public Feature? AttachedFeature { get; set; }
    }
}