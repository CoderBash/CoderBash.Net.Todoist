using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// Delete a task and all of its sub-tasks.
    /// </summary>
    public class DeleteTaskCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; } = null!;

        protected override string CommandType => "item_delete";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrEmpty(Id))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Id)));
            }

            return errors.None();
        }
    }
}
