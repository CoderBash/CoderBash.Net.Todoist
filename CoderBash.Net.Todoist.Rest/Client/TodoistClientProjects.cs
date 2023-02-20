using System;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Rest.Models.Projects;

namespace CoderBash.Net.Todoist.Rest.Client
{
	public partial interface ITodoistClient
	{
        /// <summary>
        /// Get a list of <see cref="TodoistProject"/> objects for all projects available to the user.
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="TodoistProject"/> objects.</returns>
        Task<List<TodoistProject>> GetProjectsAsync(CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a <see cref="TodoistProject"/> by ID.
        /// </summary>
        /// <param name="projectId">The ID of the project.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistProject"/> object.</returns>
        Task<TodoistProject> GetProjectByIdAsync(string projectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new project in the user's space and returns the complete <see cref="TodoistProject"/> object.
        /// </summary>
        /// <param name="model"><see cref="CreateTodoistProjectModel"/> model containing all required and optional parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistProject"/> object.</returns>
        Task<TodoistProject> CreateProjectAsync(CreateTodoistProjectModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing project in the user's space and returns the updated <see cref="TodoistProject"/> object.
        /// </summary>
        /// <param name="projectId">The ID of the project to update.</param>
        /// <param name="model"><see cref="UpdateTodoistProjectModel"/> model containing all required and optional parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistProject"/> object.</returns>
        Task<TodoistProject> UpdateProjectAsync(string projectId, UpdateTodoistProjectModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing project in the user's space.
        /// </summary>
        /// <param name="projectId">The ID of the project to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><c>True</c> if the project was deleted succesfully.</returns>
        Task<bool> DeleteProjectAsync(string projectId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Get all collaborators for a shared project.
        /// </summary>
        /// <param name="projectId">The ID of the collaborator's project.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="TodoistProjectCollaborator"/> objects.</returns>
        Task<List<TodoistProjectCollaborator>> GetProjectCollaboratorsAsync(string projectId, CancellationToken cancellationToken = default);
    }

	public sealed partial class TodoistClient
	{
        public async Task<List<TodoistProject>> GetProjectsAsync(CancellationToken cancellationToken = default)
        {
            return await GetAsync<List<TodoistProject>>("projects", cancellationToken: cancellationToken);
        }

        public async Task<TodoistProject> GetProjectByIdAsync(string projectId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<TodoistProject>($"projects/{projectId}", cancellationToken: cancellationToken);
        }

        public async Task<TodoistProject> CreateProjectAsync(CreateTodoistProjectModel model, CancellationToken cancellationToken = default)
        {
            var body = new Dictionary<string, object>()
            {
                ["name"] = model.Name
            };

            body.TryAddValue("parent_id", model.ParentId);
            body.TryAddValue("color", TodoistColorsUtils.GetColorKey(model.Color));
            body.TryAddValue("view_style", TodoistViewStylesUtils.GetViewStyleKey(model.ViewStyle));
            body.TryAddValue("is_favorite", model.IsFavorite);

            return await PostAsync<TodoistProject>("projects", body, cancellationToken: cancellationToken);
        }

        public async Task<TodoistProject> UpdateProjectAsync(string projectId, UpdateTodoistProjectModel model, CancellationToken cancellationToken = default)
        {
            var body = new Dictionary<string, object>();

            // TODO don't execute anything if no properties have been set

            body.TryAddValue("name", model.Name);
            body.TryAddValue("color", TodoistColorsUtils.GetColorKey(model.Color));
            body.TryAddValue("view_style", TodoistViewStylesUtils.GetViewStyleKey(model.ViewStyle));
            body.TryAddValue("is_favorite", model.IsFavorite);

            return await PostAsync<TodoistProject>($"projects/{projectId}", body, cancellationToken: cancellationToken);
        }

        public async Task<bool> DeleteProjectAsync(string projectId, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync($"projects/{projectId}", cancellationToken: cancellationToken);
        }

        public async Task<List<TodoistProjectCollaborator>> GetProjectCollaboratorsAsync(string projectId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<List<TodoistProjectCollaborator>>($"projects/{projectId}/collaborators", cancellationToken: cancellationToken);
        }
	}
}

