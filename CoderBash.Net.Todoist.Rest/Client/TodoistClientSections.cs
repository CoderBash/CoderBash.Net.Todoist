using System;
using CoderBash.Net.Todoist.Common.Exceptions;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Rest.Models.Sections;

namespace CoderBash.Net.Todoist.Rest.Client
{
	public partial interface ITodoistClient
	{
        /// <summary>
        /// Get all sections available in the user's space. Can be optionally filtered by project ID.
        /// </summary>
        /// <param name="projectId">(Optional) ID of the project for which the sections need to be fetched</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A list of <see cref="TodoistSection"/> objects.</returns>
        Task<List<TodoistSection>> GetAllSectionsAsync(string projectId = "", CancellationToken cancellationToken = default);

        /// <summary>
        /// Get a specific section by ID.
        /// </summary>
        /// <param name="sectionId">The ID of the section.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistSection"/> object.</returns>
        Task<TodoistSection> GetSectionByIdAsync(string sectionId, CancellationToken cancellationToken = default);

        /// <summary>
        /// Creates a new section in the user's space and returns the complete <see cref="TodoistSection"/> object.
        /// </summary>
        /// <param name="model"><see cref="CreateTodoistSectionModel"/> model containing all required and optional parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistSection"/> object.</returns>
        Task<TodoistSection> CreateSectionAsync(CreateTodoistSectionModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Updates an existing section in the user's space and returns the updated <see cref="TodoistSection"/> object.
        /// </summary>
        /// <param name="sectionId">The ID of the section to update.</param>
        /// <param name="model"><see cref="UpdateTodoistSectionModel"/> model containing all required and optional parameters.</param>
        /// <param name="cancellationToken"></param>
        /// <returns>A <see cref="TodoistSection"/> object.</returns>
        Task<TodoistSection> UpdateSectionAsync(string sectionId, UpdateTodoistSectionModel model, CancellationToken cancellationToken = default);

        /// <summary>
        /// Deletes an existing section in the user's space.
        /// </summary>
        /// <param name="sectionId">The ID of the section to delete.</param>
        /// <param name="cancellationToken"></param>
        /// <returns><c>True</c> if the section was deleted succesfully.</returns>
        Task<bool> DeleteSectionAsync(string sectionId, CancellationToken cancellationToken = default);
    }

	public sealed partial class TodoistClient
	{
        public async Task<List<TodoistSection>> GetAllSectionsAsync(string projectId = "", CancellationToken cancellationToken = default)
        {
            var endpoint = "sections";

            if (!string.IsNullOrEmpty(projectId.Trim()))
            {
                endpoint += $"?project_id={projectId.Trim()}";
            }

            return await GetAsync<List<TodoistSection>>(endpoint, cancellationToken: cancellationToken);
        }

        public async Task<TodoistSection> GetSectionByIdAsync(string sectionId, CancellationToken cancellationToken = default)
        {
            return await GetAsync<TodoistSection>($"sections/{sectionId}", cancellationToken: cancellationToken);
        }

        public async Task<TodoistSection> CreateSectionAsync(CreateTodoistSectionModel model, CancellationToken cancellationToken = default)
        {
            var body = new Dictionary<string, object>()
            {
                ["project_id"] = model.ProjectId,
                ["name"] = model.Name
            };

            body.TryAddValue("order", model.SectionOrder);

            return await PostAsync<TodoistSection>("sections", body, cancellationToken);
        }

        public async Task<TodoistSection> UpdateSectionAsync(string sectionId, UpdateTodoistSectionModel model, CancellationToken cancellationToken = default)
        {
            if (model.Name == null)
            {
                throw new TodoistException("The 'Name' property is required when updating a section through the REST endpoint");
            }

            var body = new Dictionary<string, object>()
            {
                ["name"] = model.Name
            };

            return await PostAsync<TodoistSection>($"sections/{sectionId}", body, cancellationToken: cancellationToken);
        }

        public async Task<bool> DeleteSectionAsync(string sectionId, CancellationToken cancellationToken = default)
        {
            return await DeleteAsync($"sections/{sectionId}");
        }
    }
}

