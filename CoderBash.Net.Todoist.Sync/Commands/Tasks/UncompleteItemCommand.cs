using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// Uncomplete and restore an archived task. Any ancestor tasks or sections will also be reinstated.
    /// </summary>
    public class UncompleteItemCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; } = null!;

        protected override string CommandType => "item_uncomplete";

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
