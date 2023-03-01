using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    /// <summary>
    /// Update an existing Todoist section.
    /// </summary>
    public class UpdateSectionCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the section to update.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// (Optional) The name of the section.
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// (Optional) Whether the section's tasks are collapsed.
        /// </summary>
        public bool? Collapsed { get; set; } = null;

        protected override string CommandType => "section_update";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id
            };

            args.TryAddValue("name", Name);
            args.TryAddValue("collapsed", Collapsed);

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (Name == null && Collapsed == null)
            {
                errors.Add(new TodoistValidationError(GetType().Name, "", "At least one property should be updated."));
            }

            return errors.None();
        }
    }
}
