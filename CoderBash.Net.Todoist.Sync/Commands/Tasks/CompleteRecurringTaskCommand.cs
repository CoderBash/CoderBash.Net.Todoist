using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// Complete a recurring task. See <see cref="CloseTaskCommand"/> for a simplified version of this command.
    /// </summary>
    public class CompleteRecurringTaskCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// (Optional) The due date of the task.
        /// </summary>
        public TodoistDueDate? DueDate { get; set; }


        protected override string CommandType => "item_update_date_complete";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>
            {
                ["id"] = Id
            };

            // TODO add due date value through utility class

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            throw new NotImplementedException();
        }
    }
}
