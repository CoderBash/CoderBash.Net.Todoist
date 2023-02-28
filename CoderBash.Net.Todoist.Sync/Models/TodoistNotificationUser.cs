using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Notification User model.
    /// </summary>
    public class TodoistNotificationUser
    {
        /// <summary>
        /// The email address of the user.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// The full name of the user.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// The ID of the user.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The image ID for the users's avatar, which can be used to get an avatar from a specific url. 
        /// <para>
        /// Specifically the https://dcff1xvirvpfp.cloudfront.net/&lt;image_id&gt;_big.jpg can be used for a big (195x195 pixels) avatar, https://dcff1xvirvpfp.cloudfront.net/&lt;image_id&gt;_medium.jpg for a medium (60x60 pixels) avatar, and https://dcff1xvirvpfp.cloudfront.net/&lt;image_id&gt;_small.jpg for a small (35x35 pixels) avatar.
        /// </para>
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; set; } = null!;
    }
}
