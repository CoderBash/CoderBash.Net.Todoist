using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Label model for the Sync API. This model only applies to personal labels.
    /// </summary>
    public class TodoistLabel
    {
        /// <summary>
        /// The ID of the label.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The name of the label.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// The color of the label icon. Refer to <see cref="Common.Enums.TodoistColors"/> for available options.
        /// <para>
        /// Refer to the <see href="https://developer.todoist.com/guides/#colors">Todoist Colors Guide</see> for more information.
        /// </para>
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; } = null!;

        /// <summary>
        /// Label's order in the label list (a number, where the smallest value should place the label at the top).
        /// </summary>
        [JsonProperty("item_order")]
        public int ItemOrder { get; set; }

        /// <summary>
        /// Whether the label is marked as deleted.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// Whether the label is a favorite.
        /// </summary>
        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }
    }
}
