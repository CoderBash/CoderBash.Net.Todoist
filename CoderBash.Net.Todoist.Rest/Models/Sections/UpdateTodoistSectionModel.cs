using System;
namespace CoderBash.Net.Todoist.Rest.Models.Sections
{
	/// <summary>
	/// Model for updating an existing <see cref="TodoistSection">Todoist Section</see>.
	/// </summary>
	public class UpdateTodoistSectionModel
	{
        /// <summary>
        /// [Optional] The name of the section. This property is required for the Rest endpoint.
        /// </summary>
        public string? Name { get; set; } = null;

        /// <summary>
        /// [Optional] Whether the section's tasks are collapsed. Only supported the Sync endpoint.
        /// </summary>
        public bool? IsCollapsed { get; set; } = null;
    }
}

