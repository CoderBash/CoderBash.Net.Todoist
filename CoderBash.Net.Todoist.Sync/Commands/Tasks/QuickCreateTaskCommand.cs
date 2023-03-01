using CoderBash.Net.Todoist.Common.Enums;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// Model for the quick create task command (does not use the sync flow).
    /// </summary>
    public class QuickCreateTaskCommand
    {
        /// <summary>
        /// The text of the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// (Optional) The description of the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.        
        /// </summary>
        public string? Description { get; set; } = null;

        /// <summary>
        /// (Optional) The ID of the project to add the task to. If not provided, the task will be added to the user's inbox.
        /// </summary>
        public string? ProjectId { get; set; } = null;

        /// <summary>
        /// (Optional) The date of the task, added in free form text (e.g. <c>every day @ 10</c>).
        /// </summary>
        public string? DateString { get; set; } = null;

        /// <summary>
        /// (Optional) The priority of the task.
        /// </summary>
        public TodoistTaskPriorities? Priority { get; set; } = null;

        /// <summary>
        /// (Optional) The ID of the parent task. If not set, the task will be a root task.
        /// </summary>
        public string? ParentId { get; set; } = null;

        /// <summary>
        /// (Optional) The order of the task. Defines the position of the task among all tasks with the same parent.
        /// </summary>
        public int? ChildOrder { get; set; } = null;

        /// <summary>
        /// (Optional) The task's labels (a list of names that may represent either personal or shared labels).
        /// </summary>
        public string[]? Labels { get; set; } = null;

        /// <summary>
        /// (Optional) The ID of the user who assigned the task. Only applicable in shared projects.
        /// </summary>
        public string? AssignedByUserId { get; set; } = null;

        /// <summary>
        /// (Optional) The ID of the user who is responsible for accomplishing the current task. Only applicable in shared projects.
        /// </summary>
        public string? ResponsibleUserId { get; set; } = null;

        /// <summary>
        /// (Optional) Add a note directly to the task.
        /// </summary>
        public string? Note { get; set; } = null;

        /// <summary>
        /// (Optional) When this option is enabled, the default reminder will be added to the new task if it has a due date with time set.
        /// </summary>
        public bool? AutoReminder { get; set; } = null;

    }
}
