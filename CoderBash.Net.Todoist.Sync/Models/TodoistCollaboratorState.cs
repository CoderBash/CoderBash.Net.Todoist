using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Collaborator State model for the Sync API.
    /// </summary>
    public class TodoistCollaboratorState
    {
        /// <summary>
        /// The shared project ID of the user.
        /// </summary>
        [JsonProperty("project_id")]
        public string ProjectId { get; set; } = null!;

        /// <summary>
        /// The user ID of the collaborator.
        /// </summary>
        [JsonProperty("user_id")]
        public string UserId { get; set; } = null!;

        /// <summary>
        /// The status of the collaborator state, either <c>active</c> or <c>invited</c>. See <see cref="Common.Enums.TodoistCollaborationState"/> for available options.
        /// </summary>
        [JsonProperty("state")]
        public string State { get; set; } = null!;

        /// <summary>
        /// Set to true when the collaborator leaves the shared project.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }
    }
}
