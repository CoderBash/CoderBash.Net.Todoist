using System;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Models.Tasks
{
    /// <summary>
    /// Todoist Task model for the REST API endpoint. See <see href="https://developer.todoist.com/rest/v2/#tasks">Todoist Tasks</see> for more information.
    /// </summary>
    public class TodoistTask
    {
        /// <summary>
        /// Task ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// Task's project ID (read-only).
        /// </summary>
        [JsonProperty("project_id")]
        public string ProjectId { get; set; } = null!;

        /// <summary>
        /// ID of section task belongs to (read-only, will be <c>NULL</c> when the task has no parent section).
        /// </summary>
        [JsonProperty("section_id")]
        public string? SectionId { get; set; }

        /// <summary>
        /// Task content. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } = null!;

        /// <summary>
        /// A description for the task. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        [JsonProperty("description")]
        public string Description { get; set; } = null!;

        /// <summary>
        /// Flag to mark completed tasks.
        /// </summary>
        [JsonProperty("is_completed")]
        public bool IsCompleted { get; set; }

        /// <summary>
        /// The task's labels (a list of names that may represent either personal or shared labels).
        /// </summary>
        [JsonProperty("labels")]
        public string[] Labels { get; set; } = null!;

        /// <summary>
        /// ID of parent task (read-only, will be <c>NULL</c> for top-level tasks).
        /// </summary>
        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        /// <summary>
        /// Position under the same parent or project for top-level tasks (read-only).
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// Task priority from 1 (normal, default value) to 4 (urgent). See <see cref="Common.Enums.TodoistTaskPriorities"/> for more information.
        /// </summary>
        [JsonProperty("priority")]
        public int Priority { get; set; }

        /// <summary>
        /// object representing task due date/time, or <c>NULL</c> if no date is set.
        /// </summary>
        [JsonProperty("due")]
        public TodoistDueObject? Due { get; set; }

        /// <summary>
        /// URL to access this task in the Todoist web or mobile applications (read-only).
        /// </summary>
        [JsonProperty("url")]
        public string Url { get; set; } = null!;

        /// <summary>
        /// Number of task comments (read-only).
        /// </summary>
        [JsonProperty("comment_count")]
        public int NumberOfComments { get; set; }

        /// <summary>
        /// The date when the task was created (read-only).
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The ID of the user who created the task (read-only).
        /// </summary>
        [JsonProperty("creator_id")]
        public string CreatorId { get; set; } = null!;

        /// <summary>
        /// The responsible user ID (will be <c>NULL</c> if the task is unassigned).
        /// </summary>
        [JsonProperty("assignee_id")]
        public string AssigneeId { get; set; } = null!;

        /// <summary>
        /// The ID of the user who assigned the task (read-only, will be <c>NULL</c> if the task is unassigned).
        /// </summary>
        [JsonProperty("assigner_id")]
        public string AssignerId { get; set; } = null!;
    }
}

