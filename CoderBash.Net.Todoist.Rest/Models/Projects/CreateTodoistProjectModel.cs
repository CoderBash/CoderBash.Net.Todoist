using System;
using CoderBash.Net.Todoist.Common.Enums;

namespace CoderBash.Net.Todoist.Rest.Models.Projects
{
    /// <summary>
    /// Model for creating a new <see cref="TodoistProject">Todoist Project</see>.
    /// </summary>
	public class CreateTodoistProjectModel
	{
        /// <summary>
        /// The name of the project
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// [Optional] The color of the project icon. See <see cref="Common.Enums.TodoistColor" /> for available options.
        /// </summary>
        public TodoistColors? Color { get; set; } = null;

        /// <summary>
        /// [Optional] The ID of the parent project. Should be <c>NULL</c> for root projects
        /// </summary>
        public string? ParentId { get; set; } = null;

        /// <summary>
        /// [Optional] The order of the project. Defines the position of the project among all projects with the same <see cref="ParentId"/>.
        /// This feature is only supported by the Sync endpoint.
        /// </summary>
        public int? ChildOrder { get; set; } = null;

        /// <summary>
        /// [Optional] Whether the project is a favorite.
        /// </summary>
        public bool? IsFavorite { get; set; } = null;

        /// <summary>
        /// [Optional] A string value determining the way the project is displayed within the Todoist clients. See <see cref="Common.Enums.TodoistViewStyles"/> for available options.
        /// </summary>
        public TodoistViewStyles? ViewStyle { get; set; } = null;
    }
}

