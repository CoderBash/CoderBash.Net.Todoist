using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Projects
{
    /// <summary>
    /// Update an existing Todoist project.
    /// </summary>
    public class UpdateProjectCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the project to be updated.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// (Optional) The name of the project.
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// (Optional) The color of the project's icon. See <see cref="TodoistColors"/> for available options.
        /// </summary>
        public TodoistColors? Color { get; set; } = null;

        /// <summary>
        /// (Optional) Whether the project's sub-projects are collapsed.
        /// </summary>
        public bool? Collapsed { get; set; } = null;

        /// <summary>
        /// (Optional) Whether the project is a favorite.
        /// </summary>
        public bool? IsFavorite { get; set; } = null;

        /// <summary>
        /// (Optional) View style which determines how the project is displayed in Todoist Clients. See <see cref="TodoistViewStyles" /> for available options.
        /// </summary>
        public TodoistViewStyles? ViewStyle { get; set; } = null;

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

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (Name == null && Color == null && Collapsed == null && IsFavorite == null && ViewStyle == null)
            {
                errors.Add(new TodoistValidationError(GetType().Name, "", "At least one property should be updated."));
            }

            return errors.None();
        }
    }
}
