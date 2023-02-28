using CoderBash.Net.Todoist.Sync.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Commands.Projects
{
    public class ReorderProjectsModel
    {
        public string Id { get; set; } = null!;
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

    public class ReorderProjectsCommand : TodoistCommand
    {
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
    }
}
