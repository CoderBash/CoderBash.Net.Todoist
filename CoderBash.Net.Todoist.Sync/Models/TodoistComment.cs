using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Comment model for the Sync API.
    /// </summary>
    public class TodoistComment
    {
        /// <summary>
        /// The ID of the comment.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The ID of the user that posted the comment.
        /// </summary>
        [JsonProperty("posted_uid")]
        public string PostedByUserId { get; set; } = null!;

        /// <summary>
        /// The item which the comment is part of.
        /// </summary>
        [JsonProperty("item_id")]
        public string ItemId { get; set; } = null!;

        /// <summary>
        /// The content of the comment. This value may contain markdown-formatted text and hyperlinks. 
        /// Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article in the Help Center</see>.        
        /// </summary>
        [JsonProperty("content")]
        public string Content { get; set; } = null!;

        // TODO file_attachment property

        /// <summary>
        /// A list of user IDS to notify.
        /// </summary>
        [JsonProperty("uids_to_notify")]
        public string[] UserIdsToNotify { get; set; } = null!;

        /// <summary>
        /// Whether the comment is marked as deleted.
        /// </summary>
        [JsonProperty("is_deleted")]
        public bool IsDeleted { get; set; }

        /// <summary>
        /// The date when the note was posted.
        /// </summary>
        [JsonProperty("posted_at")]
        public DateTime PostedAt { get; set; }

        // TODO reactions property
    }
}