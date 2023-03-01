using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Labels
{
    /// <summary>
    /// Update the order of multiple labels in bulk.
    /// </summary>
    public class UpdateMultipleLabelOrdersCommand : TodoistCommand
    {
        /// <summary>
        /// A dictionary where the key's are label ID's and the values are the corresponding order values.
        /// </summary>
        public Dictionary<string, int> LabelOrders { get; set; } = new Dictionary<string, int>();

        protected override string CommandType => "label_update_orders";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id_order_mappings"] = LabelOrders
            };

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (LabelOrders.Count == 0)
            {
                errors.Add(new TodoistValidationError(GetType().Name, nameof(LabelOrders), "No label orders defined."));
            }

            return errors.None();
        }
    }
}
