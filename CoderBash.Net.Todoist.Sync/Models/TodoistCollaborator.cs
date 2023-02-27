using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Collaborator model for the Sync API.
    /// </summary>
    public class TodoistCollaborator
    {
        /// <summary>
        /// The user ID of the collaborator.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The email of the collaborator.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = null!;

        /// <summary>
        /// The full name of the collaborator.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// The timezone of the collaborator.
        /// </summary>
        [JsonProperty("timezone")]
        public string Timezone { get; set; } = null!;

        /// <summary>
        /// The image ID for the collaborator's avatar, which can be used to get an avatar from a specific url. 
        /// <para>
        /// Specifically the https://dcff1xvirvpfp.cloudfront.net/&lt;image_id&gt;_big.jpg can be used for a big (195x195 pixels) avatar, https://dcff1xvirvpfp.cloudfront.net/&lt;image_id&gt;_medium.jpg for a medium (60x60 pixels) avatar, and https://dcff1xvirvpfp.cloudfront.net/&lt;image_id&gt;_small.jpg for a small (35x35 pixels) avatar.
        /// </para>
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; set; } = null!;
    }
}
