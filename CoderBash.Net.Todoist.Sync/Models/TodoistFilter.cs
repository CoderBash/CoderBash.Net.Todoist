using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Filter model for the Sync API.
    /// </summary>
    public class TodoistFilter
    {
        /// <summary>
        /// The ID of the filter.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The name of the filter.
        /// </summary>
        [JsonProperty("name")] 
        public string Name { get; set; } = null!;

        /// <summary>
        /// The query to search for. For more information about Todoist Queries refer to <see href="https://todoist.com/help/articles/205248842">Queries Examples</see>.
        /// </summary>
        [JsonProperty("query")] 
        public string Query { get; set; } = null!;

        /// <summary>
        /// The color of the filter icon. Refer to <see cref="Common.Enums.TodoistColors"/> for available options.
        /// <para>
        /// Refer to the <see href="https://developer.todoist.com/guides/#colors">Todoist Colors Guide</see> for more information.
        /// </para>
        /// </summary>
        [JsonProperty("color")] 
        public string Color { get; set; } = null!;

        /// <summary>
        /// Filter's order in the filter list (where the smallest value should place the filter at the top).
        /// </summary>
        [JsonProperty("item_order")]
        public int ItemOrder { get; set; }

        /// <summary>
        /// Whether the filter is marked as deleted.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the filter is a favorite.
        /// </summary>
        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }
    }
}
