using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Labels
{
    /// <summary>
    /// Deletes all occurrences of a shared label from all active tasks.
    /// </summary>
    public class DeleteSharedLabelOccurencesCommand : TodoistCommand
    {
        /// <summary>
        /// The name of the shared label to remove.
        /// </summary>
        public string Name { get; set; } = null!;

        protected override string CommandType => "label_delete_occurrences";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>
            {
                ["name"] = Name
            };

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Name)));
            }

            return errors.None();
        }
    }
}
