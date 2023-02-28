using CoderBash.Net.Todoist.Sync.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    public class DeleteSectionCommand : TodoistCommand
    {
        public string Id { get; set; } = null!;

        protected override string CommandType => "section_delete";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id
            };

            return args;
        }
    }
}
