using CoderBash.Net.Todoist.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Common.Enums
{
    /// <summary>
    /// Todoist Log Event Object Types. Defines the type of object that a log event belongs to.
    /// </summary>
    public enum TodoistLogEventObjectType
    {
        Task,
        Comment,
        Project
    }

    /// <summary>
    /// Helper class for managing <see cref="TodoistLogEventObjectType"/> enum values.
    /// </summary>
    public static class TodoistLogEventObjectTypeUtils
    {
        /// <summary>
        /// Get the unique name of the object type. To be used when using the API.
        /// </summary>
        /// <param name="type">A <see cref="TodoistLogEventObjectType"/> enum value.</param>
        /// <returns>The unique name of the object type or <c>null</c> if not defined.</returns>
        public static string? GetObjectTypeKey(TodoistLogEventObjectType? type)
        {
            if (type == null) return null;

            return type switch
            {
                TodoistLogEventObjectType.Task => "item",
                TodoistLogEventObjectType.Comment => "note",
                TodoistLogEventObjectType.Project => "project",
                _ => null
            };
        }

        /// <summary>
        /// Get a <see cref="TodoistLogEventObjectType"/> enum value from the object type key returned by the Todoist API.
        /// </summary>
        /// <param name="typeName">A string value describing a log event object type</param>
        /// <returns>A <see cref="TodoistLogEventObjectType"/> enum value.</returns>
        /// <exception cref="InvalidKeyException"></exception>
        public static TodoistLogEventObjectType GetFromName(string typeName)
        {
            return typeName.ToLower() switch
            {
                "item" => TodoistLogEventObjectType.Task,
                "note" => TodoistLogEventObjectType.Comment,
                "project" => TodoistLogEventObjectType.Project,
                _ => throw new InvalidKeyException($"Invalid object type key '{typeName}' provided.")
            };
        }
    }
}
