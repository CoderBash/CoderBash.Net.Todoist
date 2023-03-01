using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Projects
{
    /// <summary>
    /// Unarchive a project. No ancestors will be unarchived along with the unarchived project. 
    /// Instead, the project is unarchived alone, loses any parent relationship (becomes a root project), 
    /// and is placed at the end of the list of other root projects.
    /// </summary>
    public class UnarchiveProjectCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the project to be unarchived.
        /// </summary>
        public string Id { get; set; } = null!;

        protected override string CommandType => "project_unarchive";

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
