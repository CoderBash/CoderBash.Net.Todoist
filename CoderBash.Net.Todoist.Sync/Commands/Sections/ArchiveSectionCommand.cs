using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    /// <summary>
    /// Archive a Todoist section and all its child tasks.
    /// </summary>
    public class ArchiveSectionCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the section to be archived.
        /// </summary>
        public string Id { get; set; } = null!;

        protected override string CommandType => "section_archive";

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
