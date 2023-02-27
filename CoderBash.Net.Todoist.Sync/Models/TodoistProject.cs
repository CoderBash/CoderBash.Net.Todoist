using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Project model for the Sync API.
    /// </summary>
    public class TodoistProject
    {
        /// <summary>
        /// The ID of the project.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The name of the project.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// The color of the project icon. Refer to <see cref="Common.Enums.TodoistColors"/> for available options.
        /// <para>
        /// Refer to the <see href="https://developer.todoist.com/guides/#colors">Todoist Colors Guide</see> for more information.
        /// </para>
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; } = null!;

        /// <summary>
        /// The ID of the parent project. Set to <c>null</c> for root projects.
        /// </summary>
        [JsonProperty("parent_id")]
        public string? ParentId { get; set; }

        /// <summary>
        /// The order of the project. Defines to position of the project among all the projects with the same <see cref="ParentId"/>
        /// </summary>
        [JsonProperty("child_order")]
        public int ChildOrder { get; set; }

        /// <summary>
        /// Whether the project's sub-projects are collapsed.
        /// </summary>
        [JsonProperty("collapsed")]
        public bool IsCollapsed { get; set; }

        /// <summary>
        /// Whether the project is shared.
        /// </summary>
        [JsonProperty("shared")]
        public bool IsShared { get; set; }

        /// <summary>
        /// Whether the project is marked as deleted.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the project is marked as archived.
        /// </summary>
        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        /// <summary>
        /// Whether the project is marked as favorite.
        /// </summary>
        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }

        /// <summary>
        /// Identifier to find the match between different copies of shared projects. 
        /// When you share a project, its copy has a different ID for your collaborators. 
        /// To find a project in a different account that matches yours, you can use the "sync_id" attribute. 
        /// For non-shared projects the attribute is set to <c>null</c>.
        /// </summary>
        [JsonProperty("sync_id")]
        public string? SyncId { get; set; }

        /// <summary>
        /// Whether the project is the Inbox.
        /// </summary>
        [JsonProperty("inbox_project")]
        public bool IsInboxProject { get; set; }

        /// <summary>
        /// Whether the project is the TeamInbox.
        /// </summary>
        [JsonProperty("team_inbox")]
        public bool IsTeamInbox { get; set; }

        /// <summary>
        /// A string value that determines the way a project is displayed within the Todoist clients. See <see cref="Common.Enums.TodoistViewStyles"/> for available options.
        /// </summary>
        [JsonProperty("view_style")]
        public string ViewStyle { get; set; } = null!;
    }
}
