using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Labels
{
    /// <summary>
    /// Update an existing personal Todoist label.
    /// </summary>
    public class UpdatePersonalLabelCommand : TodoistCommand
    {
        /// <summary>
        /// The ID of the label to be updated.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// (Optional) The name of the label.
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// (Optional) The color of the label's icon. See <see cref="TodoistColors"/> for available options.
        /// </summary>
        public TodoistColors? Color { get; set; } = null;

        /// <summary>
        /// (Optional) The order of the label in the label list (the smallest value puts the label on top).
        /// </summary>
        public int? Order { get; set; } = null;

        /// <summary>
        /// (Optional) Whether the label is a favorite.
        /// </summary>
        public bool? IsFavorite { get; set; } = null;

        protected override string CommandType => "label_update";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id
            };

            args.TryAddValue("name", Name);
            args.TryAddValue("color", TodoistColorsUtils.GetColorKey(Color));
            args.TryAddValue("item_order", Order);
            args.TryAddValue("is_favorite", IsFavorite);

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (Name == null && Color == null && Order == null && IsFavorite == null)
            {
                errors.Add(new TodoistValidationError(GetType().Name, "", "At least one property should be updated."));
            }

            return errors.None();
        }
    }
}
