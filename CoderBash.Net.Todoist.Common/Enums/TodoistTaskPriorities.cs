using System;
namespace CoderBash.Net.Todoist.Common.Enums
{
    /// <summary>
    /// Todoist Task Priorities. See <see href="https://todoist.com/help/articles/introduction-to-priorities">Todoist Task Priorities</see> page for more information.
    /// </summary>
    public enum TodoistTaskPriorities
    {
        None = 1,
        P3 = 2,
        P2 = 3,
        P1 = 4
    }

    /// <summary>
    /// Helper class for managing <see href="https://todoist.com/help/articles/introduction-to-priorities">Todoist Task Priorities</see>.
    /// </summary>
    public static class TodoistTaskPrioritiesUtils
    {
        public static TodoistTaskPriorities GetFromValue(int priorityValue)
        {
            return (TodoistTaskPriorities)priorityValue;
        }

        /// <summary>
        /// Get the specific filter label for building task filters that include priority
        /// </summary>
        /// <param name="priority"><see cref="TodoistTaskPriorities"/> enum value.</param>
        /// <returns>The filter label corresponding to the task priority.</returns>
        public static string? GetFilterLabel(TodoistTaskPriorities? priority)
        {
            if (priority == null)
            {
                return null;
            }

            return priority switch
            {
                TodoistTaskPriorities.P3 => "p3",
                TodoistTaskPriorities.P2 => "p2",
                TodoistTaskPriorities.P1 => "p1",
                _ => ""
            };
        }
    }
}

