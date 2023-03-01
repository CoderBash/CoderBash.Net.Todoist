using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    /// <summary>
    /// Unarchive a Todoist section.
    /// </summary>
    public class UnarchiveSectionCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the section to unarchive.
        /// </summary>
        public string Id { get; set; } = null!;

        protected override string CommandType => "section_unarchive";

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

            if (string.IsNullOrWhiteSpace(Id))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Id)));
            }

            return errors.None();
        }
    }
}
