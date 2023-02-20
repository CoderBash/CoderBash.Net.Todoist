using System;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Rest.Models.Tasks;

namespace CoderBash.Net.Todoist.Rest.Client
{
	public partial interface ITodoistClient
	{
        Task<List<TodoistTask>> GetActiveTasksAsync(CancellationToken cancellationToken = default);
        Task<List<TodoistTask>> GetActiveTasksForProjectAsync(string projectId, CancellationToken cancellationToken = default);
        Task<List<TodoistTask>> GetActiveTasksForSectionAsync(string sectionId, CancellationToken cancellationToken = default);
        Task<List<TodoistTask>> GetActiveTasksForLabelAsync(string label, CancellationToken cancellationToken = default);

        Task<List<TodoistTask>> GetActiveTasksForFilterAsync(string filter, TodoistLanguages? language = null, CancellationToken cancellationToken = default);
        Task<TodoistTask> GetTaskByIdAsync(string taskId, CancellationToken cancellationToken = default);

        Task<TodoistTask> CreateTaskAsync(CreateTodoistTaskModel model, CancellationToken cancellationToken = default);
        Task<TodoistTask> UpdateTaskAsync(string taskId, UpdateTodoistTaskModel model, CancellationToken cancellationToken = default);

        Task<bool> CloseTaskAsync(string taskId, CancellationToken cancellationToken = default);
        Task<bool> ReopenTaskAsync(string taskId, CancellationToken cancellationToken = default);
        Task<bool> DeleteTaskAsync(string taskId, CancellationToken cancellationToken = default);
    }

	public sealed partial class TodoistClient
	{
        public async Task<List<TodoistTask>> GetActiveTasksAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync<List<TodoistTask>>("tasks", cancellationToken);
        }

        public async Task<List<TodoistTask>> GetActiveTasksForProjectAsync(string projectId, CancellationToken cancellationToken = default)
        {
            return await GetActiveTasksByParameterAsync("project_id", projectId, cancellationToken: cancellationToken);
        }

        public async Task<List<TodoistTask>> GetActiveTasksForSectionAsync(string sectionId, CancellationToken cancellationToken = default)
        {
            return await GetActiveTasksByParameterAsync("section_id", sectionId, cancellationToken: cancellationToken);
        }

        public async Task<List<TodoistTask>> GetActiveTasksForLabelAsync(string label, CancellationToken cancellationToken = default)
        {
            return await GetActiveTasksByParameterAsync("label", label, cancellationToken: cancellationToken);
        }

        public async Task<List<TodoistTask>> GetActiveTasksForFilterAsync(string filter, TodoistLanguages? language = null, CancellationToken cancellationToken = default)
        {
            var endpoint = $"tasks?filter={filter}";

            if (language != null)
            {
                endpoint += $"&lang={TodoistLanguagesUtils.GetLanguageKey(language)}";
            }

            return await GetAsync<List<TodoistTask>>(endpoint, cancellationToken);
        }

        public async Task<TodoistTask> GetTaskByIdAsync(string taskId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<TodoistTask>($"tasks/{taskId}", cancellationToken);
        }

        public async Task<TodoistTask> CreateTaskAsync(CreateTodoistTaskModel model, CancellationToken cancellationToken = default)
        {
            var body = new Dictionary<string, object>()
            {
                ["content"] = model.Content
            };

            body.TryAddValue("description", model.Description);
            body.TryAddValue("project_id", model.ProjectId);
            body.TryAddValue("section_id", model.SectionId);
            body.TryAddValue("parent_id", model.ParentId);
            body.TryAddValue("order", model.Order);
            body.TryAddValue("labels", model.Labels);
            body.TryAddValue("priority", model.Priority);
            body.TryAddValue("due_string", model.DueString);
            body.TryAddValue("due_date", model.DueDate?.Date.ToString("yyyy-MM-dd") ?? null);
            body.TryAddValue("due_datetime", model.DueDateTime?.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ") ?? null);
            body.TryAddValue("due_lang", TodoistLanguagesUtils.GetLanguageKey(model.DueLanguage));
            body.TryAddValue("assignee_id", model.AssigneeId);

            return await PostAsync<TodoistTask>("tasks", body, cancellationToken);
        }

        public async Task<TodoistTask> UpdateTaskAsync(string taskId, UpdateTodoistTaskModel model, CancellationToken cancellationToken = default)
        {
            var body = new Dictionary<string, object>();

            // TODO don't execute anything if no properties are modified
            body.TryAddValue("content", model.Content);
            body.TryAddValue("description", model.Description);
            body.TryAddValue("labels", model.Labels);
            body.TryAddValue("priority", model.Priority);
            body.TryAddValue("due_string", model.DueString);
            body.TryAddValue("due_date", model.DueDate?.Date.ToString("yyyy-MM-dd") ?? null);
            body.TryAddValue("due_datetime", model.DueDateTime?.ToString("yyyy-MM-ddTHH:mm:ss.ffffffZ") ?? null);
            body.TryAddValue("due_lang", TodoistLanguagesUtils.GetLanguageKey(model.DueLanguage));
            body.TryAddValue("assignee_id", model.AssigneeId);

            return await PostAsync<TodoistTask>($"tasks/{taskId}", body, cancellationToken);
        }

        public async Task<bool> CloseTaskAsync(string taskId, CancellationToken cancellationToken = default)
        {
            return await PostAsync($"tasks/{taskId}/close", cancellationToken: cancellationToken);
        }

        public async Task<bool> ReopenTaskAsync(string taskId, CancellationToken cancellationToken = default)
        {
            return await PostAsync($"tasks/{taskId}/reopen", cancellationToken: cancellationToken);
        }

        public async Task<bool> DeleteTaskAsync(string taskId, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync($"tasks/{taskId}", cancellationToken);
        }

        private async Task<List<TodoistTask>> GetActiveTasksByParameterAsync(string parameterKey, string parameterValue, CancellationToken cancellationToken = default)
        {
            var endpoint = $"tasks?{parameterKey}={parameterValue}";
            return await GetAsync<List<TodoistTask>>(endpoint, cancellationToken);
        }
    }
}

