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
    public class UpdateProjectCommand : TodoistCommand
    {
        public string Id { get; set; } = null!;
        public string? Name { get; set; }
        public TodoistColors? Color { get; set; }
        public bool? Collapsed { get; set; }
        public bool? IsFavorite { get; set; }
        public TodoistViewStyles? ViewStyle { get; set; }

        protected override string CommandType => "project_update";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id
            };

            args.TryAddValue("name", Name);
            args.TryAddValue("color", TodoistColorsUtils.GetColorKey(Color));
            args.TryAddValue("collapsed", Collapsed);
            args.TryAddValue("is_favorite", IsFavorite);
            args.TryAddValue("view_style", TodoistViewStylesUtils.GetViewStyleKey(ViewStyle));

            return args;
        }
    }
}
