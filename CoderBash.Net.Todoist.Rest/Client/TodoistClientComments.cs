using System;
using CoderBash.Net.Todoist.Rest.Models.Comments;

namespace CoderBash.Net.Todoist.Rest.Client
{
	public partial interface ITodoistClient
	{
        /// <summary>
        /// Get a list of <see cref="TodoistComment"/> objects with comments for the specified project id.
        /// </summary>
        /// <param name="projectId">The ID of the comment's project.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of <see cref="TodoistComment"/> objects.</returns>
		Task<List<TodoistComment>> GetProjectCommentsAsync(string projectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a list of <see cref="TodoistComment"/> objects with comments for the specified task id.
        /// </summary>
        /// <param name="taskId">The ID of the comment's task.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>List of <see cref="TodoistComment"/> objects.</returns>
		Task<List<TodoistComment>> GetTaskCommentsAsync(string taskId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a single <see cref="TodoistComment"/> object.
        /// </summary>
        /// <param name="commentId">The ID of the comment.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistComment"/> object.</returns>
		Task<TodoistComment> GetCommentAsync(string commentId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new comment for the specified project and returns the complete <see cref="TodoistComment"/> object.
        /// </summary>
        /// <param name="model"><see cref="CreateTodoistCommentModel"/> model containing all required and optional parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistComment"/> object.</returns>
		Task<TodoistComment> AddCommentToProjectAsync(CreateTodoistCommentModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new comment for the specified task and returns the complete <see cref="TodoistComment"/> object.
        /// </summary>
        /// <param name="model"><see cref="CreateTodoistCommentModel"/> model containing all required and optional parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistComment"/> object.</returns>
		Task<TodoistComment> AddCommentToTaskAsync(CreateTodoistCommentModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing comment and returns the updated <see cref="TodoistComment"/> object.
        /// </summary>
        /// <param name="commentId">The ID of the comment to update.</param>
        /// <param name="model"><see cref="UpdateTodoistCommentModel"/> model containing all required and optional parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistComment"/> object.</returns>
		Task<TodoistComment> UpdateCommentAsync(string commentId, UpdateTodoistCommentModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes a comment.
        /// </summary>
        /// <param name="commentId">The ID of the comment to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><c>True</c> if the comment was succesfully deleted</returns>
		Task<bool> DeleteCommentAsync(string commentId, CancellationToken cancellationToken = default);
	}

	public sealed partial class TodoistClient
	{
        public async Task<List<TodoistComment>> GetProjectCommentsAsync(string projectId, CancellationToken cancellationToken = default)
		{
            return await GetAsync<List<TodoistComment>>($"comments?project_id={projectId}", cancellationToken: cancellationToken);
		}

        public async Task<List<TodoistComment>> GetTaskCommentsAsync(string taskId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<List<TodoistComment>>($"comments?task_id={taskId}", cancellationToken: cancellationToken);
        }

        public async Task<TodoistComment> GetCommentAsync(string commentId, CancellationToken cancellationToken = default)
		{
            return await GetAsync<TodoistComment>($"comments/{commentId}", cancellationToken: cancellationToken);
        }

        public async Task<TodoistComment> AddCommentToProjectAsync(CreateTodoistCommentModel model, CancellationToken cancellationToken = default)
		{
            var body = new Dictionary<string, object>()
            {
                ["project_id"] = model.ParentId,
                ["content"] = model.Content
            };

            // TODO support attachments

            return await PostAsync<TodoistComment>("comments", body, cancellationToken: cancellationToken);
        }

        public async Task<TodoistComment> AddCommentToTaskAsync(CreateTodoistCommentModel model, CancellationToken cancellationToken = default)
		{
            var body = new Dictionary<string, object>()
            {
                ["task_id"] = model.ParentId,
                ["content"] = model.Content
            };

            // TODO support attachments

            return await PostAsync<TodoistComment>("comments", body, cancellationToken: cancellationToken);
        }

        public async Task<TodoistComment> UpdateCommentAsync(string commentId, UpdateTodoistCommentModel model, CancellationToken cancellationToken = default)
		{
            var body = new Dictionary<string, object>()
            {
                ["content"] = model.Content
            };

            return await PostAsync<TodoistComment>($"comments/{commentId}", body, cancellationToken: cancellationToken);
        }

        public async Task<bool> DeleteCommentAsync(string commentId, CancellationToken cancellationToken = default)
		{
            return await DeleteAsync($"comments/{commentId}", cancellationToken: cancellationToken);
        }
    }
}

