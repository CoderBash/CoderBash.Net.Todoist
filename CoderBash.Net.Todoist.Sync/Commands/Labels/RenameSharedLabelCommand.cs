using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Labels
{
    /// <summary>
    /// Update the name of a shared label. Any tasks containing a label matching the old name will be updated with the new label name.
    /// </summary>
    public class RenameSharedLabelCommand : TodoistCommand
    {
        /// <summary>
        /// The current name of the shared label.
        /// </summary>
        public string OldName { get; set; } = null!;

        /// <summary>
        /// The new name of the shared label.
        /// </summary>
        public string NewName { get; set; } = null!;

        protected override string CommandType => "label_rename";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>
            {
                ["name_old"] = OldName,
                ["name_new"] = NewName
            };

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrWhiteSpace(OldName))
            {
                errors.Add(this.GetRequiredFieldError(nameof(OldName)));
            }

            if (string.IsNullOrWhiteSpace(NewName))
            {
                errors.Add(this.GetRequiredFieldError(nameof(NewName)));
            }

            return errors.None();
        }
    }
}
