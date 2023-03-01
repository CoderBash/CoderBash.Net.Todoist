using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// A simplified version of the <see cref="CompleteTaskCommand"/> and <see cref="CompleteRecurringTaskCommand"/> commands. 
    /// <para>
    /// Regular tasks are completed and moved to the archive. Recurring tasks are scheduled for their next occurrence.
    /// </para>
    /// </summary>
    public class CloseTaskCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; } = null!;

        protected override string CommandType => "item_close";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
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
