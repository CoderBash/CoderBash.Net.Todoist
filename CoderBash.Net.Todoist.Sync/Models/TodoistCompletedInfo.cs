using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Sync.Models
{
    // TODO implement model including sub models
    /// <summary>
    /// Todoist Completed Info model for the Sync API.
    /// </summary>
    public class TodoistCompletedInfo
    {
        /// <summary>
        /// The number of completed tasks.
        /// </summary>
        [JsonProperty("completed_items")]
        public int CompletedItems { get; set; }

        // project specifics
        /// <summary>
        /// The ID of the project containing the completed tasks or archived sections. Only available for 'Project' info objects.
        /// </summary>
        [JsonProperty("project_id")]
        public string? ProjectId { get; set; }

        /// <summary>
        /// The number of archived sections within the project. Only available for 'Project' info objects.
        /// </summary>
        [JsonProperty("archived_sections")]
        public int? ArchivedSections { get; set; }

        // section specifics
        /// <summary>
        /// The ID of the section containing the completed tasks. Only available for 'Section' info objects.
        /// </summary>
        [JsonProperty("section_id")]
        public string? SectionId { get; set; }

        // item specifics
        /// <summary>
        /// The ID of the task containing the completed child tasks (only direct descendants are considered). Only available for 'Task' info objects.
        /// </summary>
        [JsonProperty("item_id")]
        public string? TaskId { get; set; }        
    }
}
