using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// Completes a task and its sub-tasks and moves them to the archive. See <see cref="CloseTaskCommand"/> for a simplified version of this command.
    /// </summary>
    public class CompleteTaskCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// (Optional) The date when the task was completed. If not set, the server will set this to the current timestamp.
        /// </summary>
        public DateTime? DateCompleted { get; set; } = null;

        protected override string CommandType => "item_complete";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>
            {
                { "id", Id }
            };

            args.TryAddValue("date_completed", DateCompleted?.ToString("yyyy-MM-dd'T'HH:mm:ss.fffK") ?? null);

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            throw new NotImplementedException();
        }
    }
}
