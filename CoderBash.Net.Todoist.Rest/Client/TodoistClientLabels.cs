using System;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Rest.Models.Labels;

namespace CoderBash.Net.Todoist.Rest.Client
{
	public partial interface ITodoistClient
	{
		/// <summary>
		/// Get a list of <see cref="TodoistLabel"/> objects for all the user's personal labels.
		/// </summary>
		/// <param name="cancellationToken"></param>
		/// <returns>A list of <see cref="TodoistLabel"/> objects.</returns>
		Task<List<TodoistLabel>> GetLabelsAsync(CancellationToken cancellationToken = default);

		/// <summary>
		/// Get a label by it's ID.
		/// </summary>
		/// <param name="labelId">The ID of the label.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>A <see cref="TodoistLabel"/> object.</returns>
		Task<TodoistLabel> GetLabelAsync(string labelId, CancellationToken cancellationToken = default);

		/// <summary>
		/// Creates a new personal label for the user and returns the complete <see cref="TodoistLabel"/> object.
		/// </summary>
		/// <param name="model"><see cref="CreateTodoistLabelModel"/> model containing all required and optional parameters.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>A <see cref="TodoistLabel"/> object.</returns>
		Task<TodoistLabel> CreateLabelAsync(CreateTodoistLabelModel model, CancellationToken cancellationToken = default);

		/// <summary>
		/// Updates a personal label for the user and returns the updated <see cref="TodoistLabel"/> object.
		/// </summary>
		/// <param name="labelId">The ID of the label to update.</param>
		/// <param name="model"><see cref="UpdateTodoistLabelModel"/> model containing all required and optional parameters.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>A <see cref="TodoistLabel"/> object.</returns>
		Task<TodoistLabel> UpdateLabelAsync(string labelId, UpdateTodoistLabelModel model, CancellationToken cancellationToken = default);

		/// <summary>
		/// Deletes a personal label for the user.
		/// </summary>
		/// <param name="labelId">The ID of the label to delete.</param>
		/// <param name="cancellationToken"></param>
		/// <returns><c>True</c> if the label was deleted succesfully.</returns>
		Task<bool> DeleteLabelAsync(string labelId, CancellationToken cancellationToken = default);

		/// <summary>
		/// Returns an array containing the names of all labels assigned to tasks. By default this call will also include all personal labels. These can be excluded by setting the <paramref name="omitPersonalLabels"/> parameter to <c>true</c>.
		/// </summary>
		/// <param name="omitPersonalLabels">Exclude personal labels from response.</param>
		/// <param name="cancellationToken"></param>
		/// <returns>Array of names of all the labels assigned to tasks.</returns>
		Task<string[]> GetSharedLabelsAsync(bool? omitPersonalLabels = null, CancellationToken cancellationToken = default);

		/// <summary>
		/// Renames all instancens of a shared label.
		/// </summary>
		/// <param name="label">The original label's name.</param>
		/// <param name="newLabelName">The new label's name.</param>
		/// <param name="cancellationToken"></param>
		/// <returns><c>True</c> if the label was updated succesfully.</returns>
		Task<bool> RenameSharedLabelAsync(string label, string newLabelName, CancellationToken cancellationToken = default);

		/// <summary>
		/// Removes all instances of the shared label from the tasks where it is applied. If no instances of the label were found, the call is still considered to be succesfull.
		/// </summary>
		/// <param name="label">The label's name.</param>
		/// <param name="cancellationToken"></param>
		/// <returns><c>True</c> if the label was deleted succesfully.</returns>s
		Task<bool> RemoveSharedLabelAsync(string label, CancellationToken cancellationToken = default);
	}

	public sealed partial class TodoistClient
	{
		public async Task<List<TodoistLabel>> GetLabelsAsync(CancellationToken cancellationToken = default)
		{
			return await GetAsync<List<TodoistLabel>>("labels", cancellationToken);
		}

		public async Task<TodoistLabel> GetLabelAsync(string labelId, CancellationToken cancellationToken = default)
		{
			return await GetAsync<TodoistLabel>($"labels/{labelId}", cancellationToken);
		}

		public async Task<TodoistLabel> CreateLabelAsync(CreateTodoistLabelModel model, CancellationToken cancellationToken = default)
		{
			var body = new Dictionary<string, object>()
			{
				["name"] = model.Name
			};

			body.TryAddValue("order", model.Order);
			body.TryAddValue("color", TodoistColorsUtils.GetColorKey(model.Color));
			body.TryAddValue("is_favorite", model.IsFavorite);

			return await PostAsync<TodoistLabel>("labels", body, cancellationToken);
		}

		public async Task<TodoistLabel> UpdateLabelAsync(string labelId, UpdateTodoistLabelModel model, CancellationToken cancellationToken = default)
		{
			var body = new Dictionary<string, object>();

			// TODO do not execute if nothing is modified
			body.TryAddValue("name", model.Name);
            body.TryAddValue("order", model.Order);
            body.TryAddValue("color", TodoistColorsUtils.GetColorKey(model.Color));
            body.TryAddValue("is_favorite", model.IsFavorite);

			return await PostAsync<TodoistLabel>($"labels/{labelId}", body, cancellationToken);
        }

		public async Task<bool> DeleteLabelAsync(string labelId, CancellationToken cancellationToken = default)
		{
			return await DeleteAsync($"labels/{labelId}", cancellationToken);
		}

		public async Task<string[]> GetSharedLabelsAsync(bool? omitPersonalLabels = null, CancellationToken cancellationToken = default)
		{
			var endpoint = "labels/shared";

			if (omitPersonalLabels != null)
			{
				endpoint += $"?omit_personal={omitPersonalLabels}";
			}

			return await GetAsync<string[]>(endpoint, cancellationToken);
		}

		public async Task<bool> RenameSharedLabelAsync(string label, string newLabelName, CancellationToken cancellationToken = default)
		{
			var body = new Dictionary<string, object>()
			{
				["name"] = label,
				["new-name"] = newLabelName
			};

			return await PostAsync("labels/shared/rename", body, cancellationToken);
		}

		public async Task<bool> RemoveSharedLabelAsync(string label, CancellationToken cancellationToken = default)
		{
			var body = new Dictionary<string, object>()
			{
				["name"] = label
			};

			return await PostAsync("labels/shared/remove", body, cancellationToken);
		}
	}
}

