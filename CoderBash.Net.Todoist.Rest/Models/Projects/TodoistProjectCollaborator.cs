using System;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Models.Projects
{
    /// <summary>
    /// Todoist Collaborator model for the Rest API.
    /// </summary>
    public class TodoistProjectCollaborator
    {
        /// <summary>
        /// The ID of the collaborator.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The email of the collaborator.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// The name of the collaborator.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}

