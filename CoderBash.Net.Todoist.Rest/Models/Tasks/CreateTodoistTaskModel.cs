using System;
using CoderBash.Net.Todoist.Common.Enums;

namespace CoderBash.Net.Todoist.Rest.Models.Tasks
{
    /// <summary>
    /// Model for creating a new <see cref="TodoistTask">Todoist Task</see>.
    /// </summary>
	public class CreateTodoistTaskModel
	{
        /// <summary>
        /// Task content. This value may contain markdown-formatted text and hyperlinks.
        /// </summary>
        public string Content { get; set; } = null!;

        /// <summary>
        /// [Optional] A description for the task. This value may contain markdown-formatted text and hyperlinks.
        /// </summary>
        public string? Description { get; set; } = null;

        /// <summary>
        /// [Optional] Task project ID. If not set, task is put to user's Inbox.
        /// </summary>
        public string? ProjectId { get; set; } = null;

        /// <summary>
        /// [Optional] ID of the section to put the task into.
        /// </summary>
        public string? SectionId { get; set; } = null;

        /// <summary>
        /// [Optional] Parent task ID.
        /// </summary>
        public string? ParentId { get; set; } = null;

        /// <summary>
        /// [Optional] Non-zero integer value used by clients to sort tasks under the same parent.
        /// </summary>
        public int? Order { get; set; } = null;

        /// <summary>
        /// [Optional] The task's labels (a list of names that may represent either personal or shared labels).
        /// </summary>
        public string[]? Labels { get; set; } = null;

        /// <summary>
        /// [Optional] Task priority from 1 (normal) to 4 (urgent). See <see cref="Common.TodoistTaskPriorities"/> for available options.
        /// </summary>
        public int? Priority { get; set; } = null;

        /// <summary>
        /// [Optional] human defined task due date. Value is set using local (not UTC) time.
        /// Only one variant of any Due* property is allowed with the exception of the <see cref="DueLanguage"/> which can accompany the <see cref="DueString"/> property.
        /// </summary>
        public string? DueString { get; set; } = null;

        /// <summary>
        /// [Optional] Specific due date. Note that with this property, only the date portion of the field will be used (YYYY-MM-DD).
        /// Only one variant of any Due* property is allowed with the exception of the <see cref="DueLanguage"/> which can accompany the <see cref="DueString"/> property.
        /// </summary>
        public DateTime? DueDate { get; set; } = null;

        /// <summary>
        /// [Optional] Specific due date. Not that with this property, the entire datetime value of the field will be used (YYYY-MM-DDTHH:MM:SS.FFF).
        /// Only one variant of any Due* property is allowed with the exception of the <see cref="DueLanguage"/> which can accompany the <see cref="DueString"/> property.
        /// </summary>
        public DateTime? DueDateTime { get; set; } = null;

        /// <summary>
        /// [Optional] 2-letter specific language in case <see cref="DueString"/> was not written in English.
        /// </summary>
        public TodoistLanguages? DueLanguage { get; set; } = null;

        /// <summary>
        /// [Optional] The responsible user ID (only applies to shared tasks).
        /// </summary>
        public string? AssigneeId { get; set; } = null;
    }
}

