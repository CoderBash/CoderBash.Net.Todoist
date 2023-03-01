using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    /// <summary>
    /// Section reorder model used in the <see cref="ReorderSectionsCommand"/>.
    /// </summary>
    public class ReorderSectionsModel
    {
        /// <summary>
        /// The ID of the section.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// The new order of the section.
        /// </summary>
        public int SectionOrder { get; set; }

        public object ToArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id,
                ["section_order"] = SectionOrder
            };

            return args;
        }
    }

    /// <summary>
    /// Updates the <see cref="TodoistSection.SectionOrder"/> property of multiple sections in bulk.
    /// </summary>
    public class ReorderSectionsCommand : TodoistCommand
    {
        /// <summary>
        /// A list of <see cref="ReorderSectionsModel"/> objects defining the new order for the related sections.
        /// </summary>
        public List<ReorderSectionsModel> Sections { get; set; } = null!;

        protected override string CommandType => "section_reorder";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["sections"] = Sections.Select(section => section.ToArgs()).ToArray()
            };

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (Sections.Count == 0)
            {
                errors.Add(new TodoistValidationError(GetType().Name, nameof(Sections), "No sections defined."));
            }

            return errors.None();
        }
    }
}
