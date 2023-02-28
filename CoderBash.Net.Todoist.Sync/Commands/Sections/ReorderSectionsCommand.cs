using CoderBash.Net.Todoist.Sync.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    public class ReorderSectionsModel
    {
        public string Id { get; set; } = null!;
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

    public class ReorderSectionsCommand : TodoistCommand
    {
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
    }
}
