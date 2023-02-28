using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Task model for the Sync API.
    /// </summary>
    public class TodoistTask
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The owner of the task.
        /// </summary>
        [JsonProperty("user_id")]
        public string TaskOwnerUserId { get; set; } = null!;

        /// <summary>
        /// The ID of the parent project.
        /// </summary>
        [JsonProperty("project_id")]
        public string ProjectId { get; set; } = null!;

        /// <summary>
        /// The text of the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } = null!;

        /// <summary>
        /// A description for the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// A <see cref="TodoistDueDate"/> object for the due date of the task.
        /// </summary>
        [JsonProperty("due")]
        public TodoistDueDate? DueDate { get; set; }

        /// <summary>
        /// Priority of the task (a number between <c>1</c> and <c>4</c>, where <c>4</c> is very urgent and <c>1</c> for natural).
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// The ID of the parent task. Set to <c>null</c> for root tasks.
        /// </summary>
        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        /// <summary>
        /// The order of the task. Defines the position of the task among all tasks with the same parent.
        /// </summary>
        [JsonProperty("child_order")]
        public int ChildOrder { get; set; }

        /// <summary>
        /// The ID of the parent section. Set to <c>null</c> for tasks not belonging to a section.
        /// </summary>
        [JsonProperty("section_id")]
        public string? SectionId { get; set; }

        /// <summary>
        /// The order of the task inside the <c>Today</c> or <c>Next 7 days</c> views (a number where the smallest value should put the task at the top of the view).
        /// </summary>
        [JsonProperty("day_order")]
        public int DayOrder { get; set; }

        /// <summary>
        /// Whether the task's subtasks are collapsed.
        /// </summary>
        [JsonProperty("collapsed")]
        public bool IsCollapsed { get; set; }

        /// <summary>
        /// The task's labels (a list of names that may represent personal and shared labels).
        /// </summary>
        [JsonProperty("labels")]
        public string[] Labels { get; set; } = null!;

        /// <summary>
        /// The ID of the user who created the task. Only sensible in a shared project context.
        /// </summary>
        [JsonProperty("added_by_uid")]
        public string? AddedByUserId { get; set; }

        /// <summary>
        /// The ID of the user who assigned the task. Only sensible in a shared project context.
        /// </summary>
        [JsonProperty("assigned_by_uid")]
        public string? AssignedByUserId { get; set; }

        /// <summary>
        /// The ID of the user who is responsible for the task. Only sensible in a shared project context.
        /// </summary>
        [JsonProperty("responsible_uid")]
        public string? ResponsibleUserId { get; set; }

        /// <summary>
        /// Whether the task is marked as completed.
        /// </summary>
        [JsonProperty("checked")]
        public bool IsChecked { get; set; }

        /// <summary>
        /// Whether the task is marked as deleted.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Identifier to find the match between tasks in shared projects of different collaborators. When you share a task, its copy has a different ID in the projects of your collaborators. To find a task in another account that matches yours, you can use the "sync_id" attribute. For non-shared tasks, the attribute is <c>null</c>.
        /// </summary>
        [JsonProperty("sync_id")]
        public string? SyncId { get; set; }

        /// <summary>
        /// The date when the task was completed (or <c>null</c> if not yet completed).
        /// </summary>
        [JsonProperty("completed_at")]
        public DateTime? CompletedAt { get; set; }

        /// <summary>
        /// The date when the task was added.
        /// </summary>
        [JsonProperty("added_at")]
        public DateTime AddedAt { get; set; }
    }
}
