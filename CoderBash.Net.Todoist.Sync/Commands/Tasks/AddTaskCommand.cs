using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    // TODO add quick add task to Client. See https://developer.todoist.com/sync/v9/#add-an-item-without-sync-workflow
    /// <summary>
    /// Add a new Todoist Task.
    /// </summary>
    public class AddTaskCommand : TodoistCommand
    {
        /// <summary>
        /// The text of the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// (Optional) The description of the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.        
        /// </summary>
        public string? Description { get; set; }

        /// <summary>
        /// (Optional) The ID of the project to add the task to. If not provided, the task will be added to the user's inbox.
        /// </summary>
        public string? ProjectId { get; set; }

        /// <summary>
        /// (Optional) The due date of the task.
        /// </summary>
        public TodoistDueDate? DueDate { get; set; }

        /// <summary>
        /// (Optional) The priority of the task.
        /// </summary>
        public TodoistTaskPriorities? Priority { get; set; }

        /// <summary>
        /// (Optional) The ID of the parent task. If not set, the task will be a root task.
        /// </summary>
        public string? ParentId { get; set; }

        /// <summary>
        /// (Optional) The order of the task. Defines the position of the task among all tasks with the same parent.
        /// </summary>
        public int? ChildOrder { get; set; }

        /// <summary>
        /// (Optional) The ID of the section. Not set for tasks not belonging to a section.
        /// </summary>
        public string? SectionId { get; set; }

        /// <summary>
        /// (Optional) The order of the task inside the 'Today' and 'Next 7 days' views (the smallest number places the task at the top of the view).
        /// </summary>
        public int? DayOrder { get; set; }

        /// <summary>
        /// (Optional) Whether the task's subtasks are collapsed.
        /// </summary>
        public bool? IsCollapsed { get; set; }

        /// <summary>
        /// (Optional) The task's labels (a list of names that may represent either personal or shared labels).
        /// </summary>
        public string[]? Labels { get; set; }

        /// <summary>
        /// (Optional) The ID of the user who assigned the task. Only applicable in shared projects.
        /// </summary>
        public string? AssignedByUserId { get; set; }

        /// <summary>
        /// (Optional) The ID of the user who is responsible for accomplishing the current task. Only applicable in shared projects.
        /// </summary>
        public string? ResponsibleUserId { get; set; }

        /// <summary>
        /// (Optional) When this option is enabled, the default reminder will be added to the new task if it has a due date with time set.
        /// </summary>
        public bool? AutoReminder { get; set; }

        /// <summary>
        /// (Optional) When this option is enabled, the labels will be parsed from the task content and added to the task. Non-existing labels will be created.
        /// </summary>
        public bool? AutoParseLabels { get; set; }

        protected override string CommandType => "item_add";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["content"] = Content
            };

            args.TryAddValue("description", Description);
            args.TryAddValue("project_id", ProjectId);
            // TODO due date --> VIa utility class
            args.TryAddValue("priority", Priority);
            args.TryAddValue("parent_id", ParentId);
            args.TryAddValue("child_order", ChildOrder);
            args.TryAddValue("section_id", SectionId);
            args.TryAddValue("day_order", DayOrder);
            args.TryAddValue("collapsed", IsCollapsed);
            args.TryAddValue("labels", Labels);
            args.TryAddValue("assigned_by_uid", AssignedByUserId);
            args.TryAddValue("responsible_uid", ResponsibleUserId);
            args.TryAddValue("auto_reminder", AutoReminder);
            args.TryAddValue("auto_parse_labels", AutoParseLabels);

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrWhiteSpace(Content))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Content)));
            }

            return errors.None();
        }
    }
}
