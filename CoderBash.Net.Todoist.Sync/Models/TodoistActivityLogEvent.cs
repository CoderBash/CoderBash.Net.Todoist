using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Activity Log Event model for the Sync API.
    /// </summary>
    public class TodoistActivityLogEvent
    {
        /// <summary>
        /// The ID of the event.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The type of the object the event belongs to. See <see cref="Common.Enums.TodoistLogEventObjectType"/> for available options.
        /// </summary>
        [JsonProperty("object_type")]
        public string ObjectType { get; set; } = null!;

        /// <summary>
        /// The ID of the object to event belongs to.
        /// </summary>
        [JsonProperty("object_id")]
        public string ObjectId { get; set; } = null!;

        /// <summary>
        /// The type of event. See <see cref="Common.Enums.TodoistLogEventType"/> for available options.
        /// </summary>
        [JsonProperty("event_type")]
        public string EventType { get; set; } = null!;

        /// <summary>
        /// The date and time when the event took place.
        /// </summary>
        [JsonProperty("event_date")]
        public DateTime EventDate { get; set; }

        /// <summary>
        /// The ID of the task's or comment's parent project, otherwise <c>null</c>.
        /// </summary>
        [JsonProperty("parent_project_id")]
        public string? ParentProjectId { get; set; }

        /// <summary>
        /// The ID of the comment's parent task, otherwise <c>null</c>.
        /// </summary>
        [JsonProperty("parent_item_id")]
        public string? ParentItemId { get; set; }

        /// <summary>
        /// The ID of the user who is responsible for the event, which only makes sense in shared projects, tasks and comments, and is <c>null</c> for non-shared objects.
        /// </summary>
        [JsonProperty("initiator_id")]
        public string? InitiatorId { get; set; }

        /// <summary>
        /// This object contains extra data about the event which can differ per event. See <see cref="TodoistActivityLogEventExtraData"/> for available options.
        /// </summary>
        [JsonProperty("extra_data")]
        public TodoistActivityLogEventExtraData? ExtraData { get; set; }
    }

    /// <summary>
    /// Todoist Activity Log Extra Data model for the Sync API.
    /// </summary>
    public class TodoistActivityLogEventExtraData
    {
        /// <summary>
        /// Name of the project. Only available on project events.
        /// </summary>
        [JsonProperty("name")]
        public string? Name { get; set; }

        /// <summary>
        /// Content of a task or comment. Only available on task and comment events.
        /// </summary>
        [JsonProperty("content")]
        public string? Content { get; set; }

        /// <summary>
        /// Previous name of the project. Only available if a project was renamed.
        /// </summary>
        [JsonProperty("last_name")]
        public string? PreviousName { get; set; }

        /// <summary>
        /// Previous content of a task or comment. Only available if the content of the task or comment has been changed.
        /// </summary>
        [JsonProperty("last_content")]
        public string? PreviousContent { get; set; }

        /// <summary>
        /// Due date of the task. Only available for task events.
        /// </summary>
        [JsonProperty("due_date")]
        public TodoistDueDate? DueDate { get; set; }

        /// <summary>
        /// Previous due date of the task. Only available if the task's due date has been changed.
        /// </summary>
        [JsonProperty("last_due_date")]
        public TodoistDueDate? PreviousDueDate { get; set; }

        /// <summary>
        /// ID of the user responsible for the task. Only available for task events.
        /// </summary>
        [JsonProperty("responsible_uid")]
        public string? ResponsibleUserId { get; set; }

        /// <summary>
        /// ID of the user previously responsible for the task. Only available for events where the responsible user of the task has been changed.
        /// </summary>
        [JsonProperty("last_responsible_uid")]
        public string? PreviousResponsibleUserId { get; set; }

        /// <summary>
        /// Client that caused the logging of an event (e.g. Mozilla/5.0; Todoist/830).
        /// </summary>
        [JsonProperty("client")]
        public string Client { get; set; } = null!;
    }
}

