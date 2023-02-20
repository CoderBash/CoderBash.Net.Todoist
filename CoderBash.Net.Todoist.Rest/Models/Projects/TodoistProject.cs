using System;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Models.Projects
{
    /// <summary>
    /// Todoist Project model for the REST API endpoint. See <see href="https://developer.todoist.com/rest/v2/#projects">Todoist Projects</see> for more information.
    /// </summary>
    public class TodoistProject
    {
        /// <summary>
        /// Project ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// Project name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// The color of the project icon. See <see cref="Common.Enums.TodoistColors"/> for available options.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; } = null!;

        /// <summary>
        /// ID of the parent project (will be <c>NULL</c> for top level projects)
        /// </summary>
        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        /// <summary>
        /// Project position under the same parent (read-only. will be 0 for inbox and team inbox projects).
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// Number of project comments
        /// </summary>
        [JsonProperty("comment_count")]
        public int NumberOfComments { get; set; }

        /// <summary>
        /// Whether the project is shared.
        /// </summary>
        [JsonProperty("is_shared")]
        public bool IsShared { get; set; }

        /// <summary>
        /// Whether the project is a favorite.
        /// </summary>
        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }

        /// <summary>
        /// Whether the project is the user's Inbox.
        /// </summary>
        [JsonProperty("is_inbox_project")]
        public bool IsInboxProject { get; set; }

        /// <summary>
        /// Whether the project is the team's Inbox.
        /// </summary>
        [JsonProperty("is_team_inbox")]
        public bool IsTeamInbox { get; set; }

        /// <summary>
        /// Determines the way a project is displayed within the todoist clients. See <see cref="Common.Enums.TodoistViewStyles"/> for available options.
        /// </summary>
        [JsonProperty("view_style")]
        public string ViewStyle { get; set; } = null!; // TODO Setup viewstyles enum

        /// <summary>
        /// URL to access this project in the Todoist web or mobile applications.
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } = null!;
    }
}

