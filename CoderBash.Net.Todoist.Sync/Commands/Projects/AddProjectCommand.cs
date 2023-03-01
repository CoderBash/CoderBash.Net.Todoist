using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Projects
{
    /// <summary>
    /// Add a new Todoist project.
    /// </summary>
    public class AddProjectCommand : TodoistCommand
    {
        /// <summary>
        /// The name of the project.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// (Optional) The color of the project's icon. See <see cref="TodoistColors"/> for available options.
        /// </summary>
        public TodoistColors? Color { get; set; } = null;

        /// <summary>
        /// (Optional) The ID of the parent project. 
        /// </summary>
        public string? ParentId { get; set; } = null;

        /// <summary>
        /// (Optional) The order of the project. Defines the position of the project among all projects with the same <see cref="ParentId"/>.
        /// </summary>
        public int? ChildOrder { get; set; } = null;

        /// <summary>
        /// (Optional) Whether the project is a favorite.
        /// </summary>
        public bool? IsFavorite { get; set; } = null;

        /// <summary>
        /// (Optional) View style which determines how the project is displayed in Todoist Clients. See <see cref="TodoistViewStyles" /> for available options.
        /// </summary>
        public TodoistViewStyles? ViewStyle { get; set; } = null;

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

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (string.IsNullOrWhiteSpace(Name))
            {
                errors.Add(this.GetRequiredFieldError(nameof(Name)));
            }

            return errors.None();
        }

        /// <summary>
        /// Get a temporary ID for the resource created by this command. See <see href="https://developer.todoist.com/sync/v9/#temporary-resource-id">Temporary Resource Id Documentation</see> for more information.
        /// <para>
        /// Useful when chaining multiple commands.
        /// </para>
        /// </summary>
        /// <returns>The temporary ID for the project created by this command.</returns>
        public string GetTemporaryId()
        {
            if (string.IsNullOrEmpty(_temporaryId))
            {
                _temporaryId = Guid.NewGuid().ToString();
            }

            return _temporaryId;
        }
    }
}
