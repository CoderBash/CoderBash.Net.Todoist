using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// Update a Todoist task
    /// </summary>
    public class UpdateTaskCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the task to be updated.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// (Optional) The text of the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        public string? Content { get; set; } = null;

        /// <summary>
        /// (Optional) The description of the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        public string? Description { get; set; } = null;

        /// <summary>
        /// (Optional) The due date of the task.
        /// </summary>
        public TodoistDueDate? DueDate { get; set; } = null;

        /// <summary>
        /// (Optional) The priority of the task.
        /// </summary>
        public TodoistTaskPriorities? Priority { get; set; } = null;

        /// <summary>
        /// (Optional) Whether the task's sub-tasks are collapsed.
        /// </summary>
        public bool? IsCollapsed { get; set; } = null;

        /// <summary>
        /// (Optional) The task's labels (a list of names that may represent either personal or shared labels).
        /// </summary>
        public string[]? Labels { get; set; } = null;

        /// <summary>
        /// (Optional) The ID of the user who assigned the task. Only applicable in shared projects.
        /// </summary>
        public string? AssignedByUserId { get; set; } = null;

        /// <summary>
        /// (Optional) The ID of the user who is responsible for accomplishing the task. Only applicable in shared projects.
        /// </summary>
        public string? ResponsibleUserId { get; set; } = null;

        /// <summary>
        /// (Optional) The order of the task in the 'Today' or 'Next 7 days' views (where the smallest number places the task at the top of the view).
        /// </summary>
        public int? DayOrder { get; set; } = null;

        protected override string CommandType => "item_update";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            args.TryAddValue("content", Content);
            args.TryAddValue("description", Description);
            // TODO add due date through utility class
            args.TryAddValue("priority", Priority);
            args.TryAddValue("collapsed", IsCollapsed);
            args.TryAddValue("labels", Labels);
            args.TryAddValue("assigned_by_uid", AssignedByUserId);
            args.TryAddValue("responsible_uid", ResponsibleUserId);
            args.TryAddValue("day_order", DayOrder); 

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrWhiteSpace(Id))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Id)));
            }

            if (this.IsObjectEmpty())
                errors.Add(new TodoistValidationError(GetType().Name, "", "At least one property should be updated."));

            return errors.None();
        }
    }
}
