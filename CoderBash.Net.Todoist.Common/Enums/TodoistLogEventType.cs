using CoderBash.Net.Todoist.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Common.Enums
{
    /// <summary>
    /// Todoist Log Event Types. Defines the type of a log event.
    /// </summary>
    public enum TodoistLogEventType
    {
        Added,
        Updated,
        Deleted,
        Completed,
        Uncompleted,
        Archived,
        Unarchived,
        Shared,
        Left
    }

    /// <summary>
    /// Helper class for managing <see cref="TodoistLogEventType"/> enum values.
    /// </summary>
    public static class TodoistLogEventTypeUtils
    {
        public static string? GetEventTypeKey(TodoistLogEventType? type)
        {
            if (type == null) return null;

            return type switch
            {
                TodoistLogEventType.Added => "added",
                TodoistLogEventType.Updated => "updated",
                TodoistLogEventType.Deleted => "deleted",
                TodoistLogEventType.Completed => "completed",
                TodoistLogEventType.Uncompleted => "uncompleted",
                TodoistLogEventType.Archived => "archived",
                TodoistLogEventType.Unarchived => "unarchived",
                TodoistLogEventType.Shared => "shared",
                TodoistLogEventType.Left => "left",
                _ => null
            };
        }

        public static TodoistLogEventType GetFromName(string typeName)
        {
            return typeName.ToLower() switch
            {
                "added" => TodoistLogEventType.Added,
                "updated" => TodoistLogEventType.Updated,
                "deleted" => TodoistLogEventType.Deleted,
                "completed" => TodoistLogEventType.Completed,
                "uncompleted" => TodoistLogEventType.Uncompleted,
                "archived" => TodoistLogEventType.Archived, 
                "unarchived" => TodoistLogEventType.Unarchived,
                "shared" => TodoistLogEventType.Shared, 
                "left" => TodoistLogEventType.Left,
                _ => throw new InvalidKeyException($"Invalid event type name '{typeName}' provided.")
            };
        }
    }
}
