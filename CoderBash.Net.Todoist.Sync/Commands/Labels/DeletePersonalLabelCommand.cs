using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Labels
{
    /// <summary>
    /// Deletes a personal label.
    /// </summary>
    public class DeletePersonalLabelCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the label to be deleted.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// If <see cref="ShouldCascade"/> is <c>true</c> (Default behavior), all instances of the label will be removed from tasks (including shared projects).
        /// If set to <c>false</c> the personal label will be removed from the user's account, but it will continue to appear on tasks as a shared label.
        /// </summary>
        public bool ShouldCascade { get; set; } = true;

        protected override string CommandType => "label_delete";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>
            {
                ["id"] = Id,
                ["cascade"] = ShouldCascade ? "all" : "none"
            };

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
