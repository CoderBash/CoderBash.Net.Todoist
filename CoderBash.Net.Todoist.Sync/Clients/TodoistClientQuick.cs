using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Commands.Tasks;
using CoderBash.Net.Todoist.Sync.Models;

namespace CoderBash.Net.Todoist.Sync.Clients
{
    public partial interface ITodoistClient
    {
        Task<TodoistTask> QuickAddTaskAsync(string content, string? note = null, string? reminder = null, bool? autoReminder = null, CancellationToken cancellationToken = default);
        Task<TodoistTask> QuickCreateTaskAsync(QuickCreateTaskCommand model, CancellationToken cancellationToken = default);
    }

    public sealed partial class TodoistClient
    {
        public async Task<TodoistTask> QuickAddTaskAsync(string content, string? note = null, string? reminder = null, bool? autoReminder = null, CancellationToken cancellationToken = default)
        {
            var data = new Dictionary<string, object>
            {
                ["text"] = content
            };

            data.TryAddValue("note", note);
            data.TryAddValue("reminder", reminder);
            data.TryAddValue("auto_reminder", autoReminder);

            return await PostFormAsync<TodoistTask>("quick/add", data.ToKeyValuePairs(), cancellationToken);
        }

        public async Task<TodoistTask> QuickCreateTaskAsync(QuickCreateTaskCommand model, CancellationToken cancellationToken = default)
        {
            var data = new Dictionary<string, object>()
            {
                ["content"] = model.Content
            };

            data.TryAddValue("description", model.Description);
            data.TryAddValue("project_id", model.ProjectId);
            data.TryAddValue("date_string", model.DateString);
            data.TryAddValue("priority", model.Priority);
            data.TryAddValue("parent_id", model.ParentId);
            data.TryAddValue("child_order", model.ChildOrder);
            data.TryAddValue("labels", model.Labels);
            data.TryAddValue("assigned_by_uid", model.AssignedByUserId);
            data.TryAddValue("responsible_uid", model.ResponsibleUserId);
            data.TryAddValue("note", model.Note);
            data.TryAddValue("auto_reminder", model.AutoReminder);

            return await PostFormAsync<TodoistTask>("items/add", data.ToKeyValuePairs(), cancellationToken);
        }
    }
}
