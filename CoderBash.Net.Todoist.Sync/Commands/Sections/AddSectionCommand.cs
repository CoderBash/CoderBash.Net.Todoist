using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    /// <summary>
    /// Add a new section to a Todoist Project.
    /// </summary>
    public class AddSectionCommand : TodoistCommand
    {
        /// <summary>
        /// The name of the section.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// The ID of the project to which the section should be added.
        /// </summary>
        public string ProjectId { get; set; } = null!;

        /// <summary>
        /// (Optional) The order of the section. Defines the position of the section among all the sections in the project.
        /// </summary>
        public int? SectionOrder { get; set; } = null;

        protected override string CommandType => "section_add";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["name"] = Name,
                ["project_id"] = ProjectId
            };

            args.TryAddValue("section_order", SectionOrder);

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Name)));
            }

            if (string.IsNullOrWhiteSpace(ProjectId))
            {
                errors.Add(this.GetRequiredFieldError(nameof(ProjectId)));
            }

            return errors.None();
        }
    }
}
