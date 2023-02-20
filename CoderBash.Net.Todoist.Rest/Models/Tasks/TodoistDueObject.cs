using System;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Models.Tasks
{
    /// <summary>
    /// Todoist Due Object model for the REST API endpoint. See 'Due object' subsection of <see href="https://developer.todoist.com/rest/v2/#tasks">Todoist Tasks</see> for more information.
    /// </summary>
    public class TodoistDueObject
    {
        /// <summary>
        /// Human defined date in arbitrary format.
        /// </summary>
        [JsonProperty("string")]
        public string HumanReadableContent { get; set; } = null!;

        /// <summary>
        /// Date in format <c>YYYY-MM-DD</c> corrected to user's timezone.
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Whether the task has a <see href="https://todoist.com/nl/help/articles/set-a-recurring-due-date">recurring due date</see>.
        /// </summary>
        [JsonProperty("is_recurring")]
        public bool IsRecurring { get; set; }

        /// <summary>
        /// Only returned if exact due time set (i.e. it's not a whole-day task), date and time in RFC3339 format in UTC.
        /// </summary>
        [JsonProperty("datetime")]
        public DateTime? ExactDateTime { get; set; }

        /// <summary>
        /// Only returned if exact due time set, user's timezone definition either in tzdata-compatible format ("Europe/Berlin") or as a string specifying east of UTC offset as "UTC±HH:MM" (i.e. "UTC-01:00").
        /// </summary>
        [JsonProperty("timezone")]
        public string? Timezone { get; set; }
    }
}

