using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Base;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Commands.Tasks
{
    /// <summary>
    /// Task Reorder model used in the <see cref="ReorderTasksCommand"/>.
    /// </summary>
    public class ReorderTasksModel
    {
        /// <summary>
        /// The ID of the task.
        /// </summary>
        public string Id { get; set; } = null!;

        /// <summary>
        /// The new order value for the task.
        /// </summary>
        public int Order { get; set; }

        public object ToArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["id"] = Id,
                ["child_order"] = Order
            };

            return args;
        }
    }

    /// <summary>
    /// Updates the order of tasks in bulk
    /// </summary>
    public class ReorderTasksCommand : TodoistCommand
    {
        /// <summary>
        /// A list of <see cref="ReorderTasksModel"/> objects 
        /// </summary>
        public List<ReorderTasksModel> Tasks { get; set; } = null!;

        protected override string CommandType => "item_reorder";

        protected override Dictionary<string, object> GetCommandArgs()
        {
            var args = new Dictionary<string, object>()
            {
                ["items"] = Tasks
            };

            return args;
        }

        internal override bool ValidateCommand(out List<TodoistValidationError> errors)
        {
            errors = new List<TodoistValidationError>();

            if (Tasks.Count == 0)
            {
                errors.Add(new TodoistValidationError(GetType().Name, nameof(Tasks), "No tasks to reorder."));
            }

            return errors.None();
        }
    }
}
