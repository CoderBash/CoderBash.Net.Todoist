using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    public class AddSectionCommand : TodoistCommand
    {
        public string Name { get; set; } = null!;
        public string ProjectId { get; set; } = null!;
        public int? SectionOrder { get; set; }

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
    }
}
