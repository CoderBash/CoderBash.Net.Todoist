using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Due Date model for the Sync API.
    /// </summary>
    public class TodoistDueDate
    {
        /// <summary>
        /// The date (and time) of the due date. Can be represented in different formats (see below) depending on the type of due date object that is being created.
        /// For all date objects, this value contains the current iteration in case of recurring dates.
        /// <para>
        /// Option 1: Due date in the format 'YYYY-MM-DD'. Use the <see cref="TodoistDueDateExtensions.GetFixedDateString(TodoistDueDate)"/> method for this format.
        /// </para>
        /// 
        /// <para>
        /// Option 2: Due date in the format 'YYYY-MM-DDTHH:MM:SS'. Use the <see cref="TodoistDueDateExtensions.GetFloatingDateString(TodoistDueDate)"/> method for this format.
        /// </para>
        /// 
        /// <para>
        /// Option 3: Due date in the format 'YYYY-MM-DDTHH:MM:SSZ'. Use the <see cref="TodoistDueDateExtensions.GetFullDateString(TodoistDueDate)"/> method for this format.
        /// Should be accompanied by a Timezone value.
        /// </para>
        /// </summary>
        [JsonProperty("date")]
        public DateTime Date { get; set; }

        /// <summary>
        /// Only used in due dates with a fixed date time with timezone scenario (see option 3 of <see cref="Date"/>).
        /// </summary>
        [JsonProperty("timezone")]
        public string? Timezone { get; set; }

        /// <summary>
        /// Human-readable representation of the due date. For more information see the <see href="https://todoist.com/help/articles/205325931">Todoist Documentation</see>.
        /// </summary>
        [JsonProperty("string")]
        public string HumanReadable { get; set; } = null!;

        /// <summary>
        /// Language which has to be used to parse the content of the <see cref="HumanReadable"/> property. See <see cref="Common.Enums.TodoistLanguages"/> for all available options.
        /// </summary>
        [JsonProperty("lang")]
        public string Language { get; set; } = null!;

        /// <summary>
        /// Whether the due date represents a recurring due date.
        /// </summary>
        [JsonProperty("is_recurring")]
        public bool IsRecurring { get; set; }
    }

    public static class TodoistDueDateExtensions
    {
        /// <summary>
        /// Helper method for fetching the <see cref="TodoistDueDate"/> date value as specified in <see href="https://developer.todoist.com/sync/v9/#full-day-dates">Todoist Full Day Dates</see>.
        /// </summary>
        /// <param name="dueDate">A <see cref="TodoistDueDate"/> object.</param>
        /// <returns>Formatted <see cref="TodoistDueDate.Date"/> value.</returns>
        public static string GetFullDateString(this TodoistDueDate dueDate)
        {
            return dueDate.Date.ToString("yyyy-MM-dd");
        }

        /// <summary>
        /// Helper method for fetching the <see cref="TodoistDueDate"/> date value as specified in <see href="https://developer.todoist.com/sync/v9/#floating-due-dates-with-time">Todoist Floating Due dates</see>.
        /// </summary>
        /// <param name="dueDate">A <see cref="TodoistDueDate"/> object.</param>
        /// <returns>Formatted <see cref="TodoistDueDate.Date"/> value.</returns>
        public static string GetFloatingDateString(this TodoistDueDate dueDate)
        {
            return dueDate.Date.ToString("yyyy-MM-dd'T'HH:mm:ss");
        }

        /// <summary>
        /// Helper method for fetching the <see cref="TodoistDueDate"/> date value as specified in <see href="https://developer.todoist.com/sync/v9/#due-dates-with-time-and-fixed-timezone">Todoist Date Time - TimeZone</see>.
        /// </summary>
        /// <param name="dueDate">A <see cref="TodoistDueDate"/> object.</param>
        /// <returns>Formatted <see cref="TodoistDueDate.Date"/> value.</returns>
        public static string GetFixedDateString(this TodoistDueDate dueDate)
        {
            return dueDate.Date.ToString("yyyy-MM-dd'T'HH:mm:ss'Z'");
        }
    }
}
