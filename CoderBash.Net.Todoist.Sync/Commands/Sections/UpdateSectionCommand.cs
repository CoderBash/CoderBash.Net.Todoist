using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Commands.Sections
{
    public class UpdateSectionCommand : TodoistCommand
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public bool? Collapsed { get; set; }

        protected override string CommandType => "section_update";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id
            };

            args.TryAddValue("name", Name);
            args.TryAddValue("collapsed", Collapsed);

            return args;
        }
    }
}
