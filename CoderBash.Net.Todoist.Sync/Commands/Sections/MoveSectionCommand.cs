using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    /// <summary>
    /// Move a Todoist section to another project.
    /// </summary>
    public class MoveSectionCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the section to be moved.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// The ID of the new parent project.
        /// </summary>
        public string ProjectId { get; set; } = null!;

        protected override string CommandType => "section_move";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id,
                ["project_id"] = ProjectId
            };

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {  
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrWhiteSpace(Id))
            {

            }

            if (string.IsNullOrWhiteSpace(ProjectId))
            {

            }

            return errors.None();
        }
    }
}
