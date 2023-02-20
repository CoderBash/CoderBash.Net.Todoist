using System;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Models.Labels
{
    /// <summary>
    /// Todoist Label model for the REST API endpoint. See <see href="https://developer.todoist.com/rest/v2/#labels">Todoist Tasks</see> for more information.
    /// </summary>
    public class TodoistLabel
	{
        /// <summary>
        /// Label ID.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// Label name.
        /// </summary>
        [JsonProperty("name")]
        public string Name { get; set; } = null!;

        /// <summary>
        /// The color of the label icon. See <see cref="Common.Enums.TodoistColors"/> for available options.
        /// </summary>
        [JsonProperty("color")]
        public string Color { get; set; } = null!;

        /// <summary>
        /// Number used by clients to sort list of labels.
        /// </summary>
        [JsonProperty("order")]
        public int Order { get; set; }

        /// <summary>
        /// Whether the label is a favorite.
        /// </summary>
        [JsonProperty("is_favorite")]
        public bool IsFavorite { get; set; }
    }
}

