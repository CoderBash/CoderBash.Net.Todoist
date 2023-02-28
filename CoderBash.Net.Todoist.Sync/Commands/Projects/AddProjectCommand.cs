using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Commands.Projects
{
    public class AddProjectCommand : TodoistCommand
    {
        public string Name { get; set; } = null!;
        public TodoistColors? Color { get; set; }
        public string? ParentId { get; set; }
        public int? ChildOrder { get; set; }
        public bool? IsFavorite { get; set; }
        public TodoistViewStyles? ViewStyle { get; set; }

        protected override string CommandType => "project_add";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["name"] = Name
            };

            args.TryAddValue("color", TodoistColorsUtils.GetColorKey(Color));
            args.TryAddValue("parent_id", ParentId);
            args.TryAddValue("child_order", ChildOrder);
            args.TryAddValue("is_favorite", IsFavorite);
            args.TryAddValue("view_style", TodoistViewStylesUtils.GetViewStyleKey(ViewStyle));

            return args;
        }
    }
}
