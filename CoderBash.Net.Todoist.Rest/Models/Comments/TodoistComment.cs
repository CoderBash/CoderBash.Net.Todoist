using System;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Models.Comments
{
    /// <summary>
    /// Todoist Comment model for the REST API endpoint. See <see href="https://developer.todoist.com/rest/v2/#comments">Todoist Comments</see> for more information.
    /// </summary>
    public class TodoistComment
	{
        /// <summary>
        /// Comment ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// Comment's task ID (can be <c>NULL</c> if the comment belongs to a project).
        /// </summary>
        [JsonProperty("task_id")]
        public string? TaskId { get; set; }

        /// <summary>
        /// Comment's project ID (can be <c>NULL</c> if the comment belongs to a task).
        /// </summary>
        [JsonProperty("project_id")]
        public string? ProjectId { get; set; }

        /// <summary>
        /// Date and time when the comment was added.
        /// </summary>
        [JsonProperty("posted_at")]
        public DateTime PostedAt { get; set; }

        /// <summary>
        /// Comment content. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } = null!;

        // TODO attachment object
    }
}

