using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Section model for the Sync API.
    /// </summary>
    public class TodoistSection
    {
        /// <summary>
        /// The ID of the section.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The name of the section.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// Project that the section resides in.
        /// </summary>
        [JsonProperty("project_id")]
        public string ProjectId { get; set; } = null!;

        /// <summary>
        /// The order of the section. Defines the position of the section among all the sections in the project.
        /// </summary>
        [JsonProperty("section_order")]
        public int SectionOrder { get; set; }

        /// <summary>
        /// Whether the section's tasks are collapsed.
        /// </summary>
        [JsonProperty("collapsed")]
        public bool IsCollapsed { get; set; }

        /// <summary>
        /// A special ID for shared sections (a number of <c>null</c> if not set). Used internally and can be ignored.
        /// </summary>
        [JsonProperty("sync_id")]
        public string? SyncId { get; set; }

        /// <summary>
        /// Whether the section is marked as deleted.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the section is marked as archived.
        /// </summary>
        [JsonProperty("is_archived")]
        public bool IsArchived { get; set; }

        /// <summary>
        /// The date when the section was archived (or <c>null</c> if not archived).
        /// </summary>
        [JsonProperty("archived_at")]
        public DateTime? ArchivedAt { get; set; }

        /// <summary>
        /// The date when the section was created.
        /// </summary>
        [JsonProperty("added_at")]
        public DateTime? AddedAt { get; set; }
    }
}
