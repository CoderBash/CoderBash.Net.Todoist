using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Projects
{
    /// <summary>
    /// Update parent project relationship of the project.
    /// </summary>
    public class MoveProjectCommand : TodoistCommand
    {
        /// <summary>
        /// The of the project.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// (Optional) The ID of the parent project. If <see cref="ParentId"/> is <c>NULL</c> the project will be moved to the root.
        /// </summary>
        public string? ParentId { get; set; } = null;

        protected override string CommandType => "project_move";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id
            };

            args.TryAddValue("parent_id", ParentId);

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrWhiteSpace(Id))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Id)));
            }

            return errors.None();
        }
    }
}
