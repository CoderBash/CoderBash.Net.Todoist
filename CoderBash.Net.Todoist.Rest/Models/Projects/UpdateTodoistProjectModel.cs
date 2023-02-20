using System;
using CoderBash.Net.Todoist.Common.Enums;

namespace CoderBash.Net.Todoist.Rest.Models.Projects
{
    /// <summary>
    /// Model for updating an existing <see cref="TodoistProject">Todoist Project</see>.
    /// </summary>
	public class UpdateTodoistProjectModel
	{
        /// <summary>
        /// [Optional] The name of the project
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// [Optional] The color of the project icon. See <see cref="Common.TodoistColor" /> for available options.
        /// </summary>
        public TodoistColors? Color { get; set; } = null;

        /// <summary>
        /// [Optional] Whether the project's sub-projects are collapsed. Only supported by the Sync endpoint.
        /// </summary>
        public bool? IsCollapsed { get; set; } = null;

        /// <summary>
        /// [Optional] Whether the project is a favorite.
        /// </summary>
        public bool? IsFavorite { get; set; } = null;

        /// <summary>
        /// [Optional] A string value determining the way the project is displayed within the Todoist clients. See <see cref="Common.TodoistViewStyles"/> for available options.
        /// </summary>
        public TodoistViewStyles? ViewStyle { get; set; } = null;
    }
}

