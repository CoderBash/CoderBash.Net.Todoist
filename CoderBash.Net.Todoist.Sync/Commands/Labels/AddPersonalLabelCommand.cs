using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Extensions;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Labels
{
    /// <summary>
    /// Add a new personal label.
    /// </summary>
    public class AddPersonalLabelCommand : TodoistCommand
    {
        /// <summary>
        /// The name of the label.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// (Optional) The color of the label's icon. See <see cref="TodoistColors"/> for available options.
        /// </summary>
        public TodoistColors? Color { get; set; } = null;

        /// <summary>
        /// (Optional) Label's order in the label list (smallest value puts the label at the top of the list).
        /// </summary>
        public int? Order { get; set; } = null;

        /// <summary>
        /// (Optional) Whether the label is a favorite.
        /// </summary>
        public bool? IsFavorite { get; set; } = null;

        protected override string CommandType => "label_add";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>
            {
                ["name"] = Name
            };

            args.TryAddValue("color", TodoistColorsUtils.GetColorKey(Color));
            args.TryAddValue("item_order", Order);
            args.TryAddValue("is_favorite", IsFavorite);

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
    }
}
