using System;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Models.Sections
{
    /// <summary>
    /// Todoist Section model for the REST API endpoints. See <see href="https://developer.todoist.com/rest/v2/#sections">Todoist Sections</see> for more information.
    /// </summary>
    public class TodoistSection
    {
        /// <summary>
        /// Section ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// ID of the project the section belongs to.
        /// </summary>
        [JsonProperty("project_id")]
        public string ProjectId { get; set; } = null!;

        /// <summary>
        /// Section position among other sections from the same project.
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// Section name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}

