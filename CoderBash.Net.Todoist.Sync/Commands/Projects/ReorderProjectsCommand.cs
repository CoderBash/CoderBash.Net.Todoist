using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Commands.Projects
{
    /// <summary>
    /// Project reorder model used in the <see cref="ReorderProjectsCommand"/>.
    /// </summary>
    public class ReorderProjectsModel
    {
        /// <summary>
        /// The ID of the project.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// The new order of the project.
        /// </summary>
        public int ChildOrder { get; set; }

        public object ToArgs()
        {
            var args = new Dictionary<string, object>
            {
                ["id"] = Id,
                ["child_order"] = ChildOrder
            };

            return args;
        }
    }

    /// <summary>
    /// Updates the <see cref="TodoistProject.ChildOrder"/> property of multiple projects in bulk.
    /// </summary>
    public class ReorderProjectsCommand : TodoistCommand
    {
        /// <summary>
        /// A list of <see cref="ReorderProjectsModel"/> objects defining the new order for the related projects.
        /// </summary>
        public List<ReorderProjectsModel> Projects { get; set; } = null!;

        protected override string CommandType => "project_reorder";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["projects"] = Projects.Select(project => project.ToArgs()).ToArray()
            };

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (Projects.Count == 0)
            {
                errors.Add(new TodoistValidationError(GetType().Name, nameof(Projects), "No projects defined."));
            }

            return errors.None();
        }
    }
}
