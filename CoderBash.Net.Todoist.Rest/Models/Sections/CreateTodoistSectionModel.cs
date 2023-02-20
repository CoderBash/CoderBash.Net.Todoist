using System;
namespace CoderBash.Net.Todoist.Rest.Models.Sections
{
	/// <summary>
	/// Model for creating a new <see cref="TodoistSection">Todoist Section</see>.
	/// </summary>
	public class CreateTodoistSectionModel
	{
        /// <summary>
        /// The name of the section.
        /// </summary>
        public string Name { get; set; } = null!;

        /// <summary>
        /// The ID of the parent project.
        /// </summary>
        public string ProjectId { get; set; } = null!;

        /// <summary>
        /// [Optional] The order of the section. Defines the position of the section among all the sections in the project.
        /// </summary>
        public int? SectionOrder { get; set; } = null;
    }
}

