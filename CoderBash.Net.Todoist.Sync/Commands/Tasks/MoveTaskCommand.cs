using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// Move the task to a different location. Only one of the <see cref="ParentId"/>, <see cref="SectionId"/> or <see cref="ProjectId"/> properties should be set.
    /// 
    /// <para>
    /// To move a task from a section to no section, use the ProjectId property with this command where the ProjectId is the task's current project.
    /// </para>
    /// </summary>
    public class MoveTaskCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// (Optional) The ID of the destination parent task. The task becomes the last child of the parent task.
        /// </summary>
        public string? ParentId { get; set; }

        /// <summary>
        /// (Optional) The ID of the destination section. The task becomes the last root task of the section.
        /// </summary>
        public string? SectionId { get; set; }

        /// <summary>
        /// (Optional) The ID of the destination project. The task becomes the last root task of the project.
        /// </summary>
        public string? ProjectId { get; set; }

        protected override string CommandType => "item_move";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id
            };

            args.TryAddValue("parent_id", ParentId);
            args.TryAddValue("section_id", SectionId);
            args.TryAddValue("project_id", ProjectId);

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrEmpty(Id))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Id)));
            }

            var notNullParentFields = 0;
            if (ParentId != null) notNullParentFields++;
            if (SectionId != null) notNullParentFields++;
            if (ProjectId != null) notNullParentFields++;

            if (notNullParentFields == 0 || notNullParentFields > 1)
            {
                errors.Add(new TodoistValidationError(GetType().Name, "", "Choose only one of the properties ParentId, SectionId, ProjectId to set a new parent for the task."));
            }

            return errors.None();
        }
    }
}
