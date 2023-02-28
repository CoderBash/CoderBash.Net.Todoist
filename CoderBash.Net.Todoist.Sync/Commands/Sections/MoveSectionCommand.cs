using CoderBash.Net.Todoist.Sync.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    public class MoveSectionCommand : TodoistCommand
    {
        public string Id { get; set; } = null!;
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
    }
}
