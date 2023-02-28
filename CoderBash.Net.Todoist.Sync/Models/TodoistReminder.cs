using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Reminder model for the Sync API.
    /// </summary>
    public class TodoistReminder
    {
        /// <summary>
        /// The ID of the reminder.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The ID of user that should be notified.
        /// </summary>
        [JsonProperty("notify_uid")]
        public string NotifyUserId { get; set; } = null!;

        /// <summary>
        /// The ID of the task which the reminder is about.
        /// </summary>
        [JsonProperty("item_id")]
        public string TaskId { get ; set; } = null!;

        /// <summary>
        /// The type of the reminder. 
        /// <c>relative</c> for a time-based reminder specified in minutes from now, 
        /// <c>absolute</c> for a time-based reminder with a specific time and date in the future,
        /// and <c>location</c> for a location-based reminder.
        /// </summary>
        [JsonProperty("type")]
        public string Type { get; set; } = null!;

        /// <summary>
        /// The due date of the reminder. Available for <c>relative</c> and <c>absolute</c> reminder types.
        /// </summary>
        [JsonProperty("due")]
        public TodoistDueDate? Due { get; set; }

        /// <summary>
        /// The relative time in minutes before the due date of the task, in which the reminder should be triggered.
        /// Available for <c>relative</c> and <c>absolute</c> reminder types (i.e. for time-based reminders).
        /// </summary>
        [JsonProperty("mm_offset")]
        public int TriggerOffset { get; set; }

        /// <summary>
        /// An alias for the location. Available in <c>location</c> reminder types
        /// </summary>
        [JsonProperty("name")]
        public string? LocationAlias { get; set; }

        /// <summary>
        /// The latitude of the location. Available in <c>location</c> reminder types
        /// </summary>
        [JsonProperty("loc_lat")]
        public string? LocationLatitude { get; set; }

        /// <summary>
        /// The longitude of the location. Available in <c>location</c> reminder types
        /// </summary>
        [JsonProperty("loc_long")]
        public string? LocationLongitude { get; set; }

        /// <summary>
        /// The type of location trigger to be used. <c>on_enter</c> for entering a location; <c>on_leave</c> for leaving the location.
        /// Available in <c>location</c> reminder types
        /// </summary>
        [JsonProperty("loc_trigger")]
        public string? LocationTrigger { get; set; }

        /// <summary>
        /// The radius around the location that is still considered part of the location (in meters). Available in <c>location</c> reminder types
        /// </summary>
        [JsonProperty("radius")]
        public int? LocationRadius { get; set; }

        /// <summary>
        /// Whether the reminder is marked as deleted (<c>1</c> is true and <c>0</c> is false).
        /// </summary>
        [JsonProperty("is_deleted")]
        public int IsDeleted { get; set; }
    }
}
