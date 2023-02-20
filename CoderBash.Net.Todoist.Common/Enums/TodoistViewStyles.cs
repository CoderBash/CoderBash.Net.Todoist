using System;
using CoderBash.Net.Todoist.Common.Exceptions;

namespace CoderBash.Net.Todoist.Common.Enums
{
    /// <summary>
    /// Todoist Project View Styles. See <see href="https://todoist.com/help/articles/manage-your-view">Todoist View Styles</see> documentation page for more information.
    /// </summary>
    public enum TodoistViewStyles
	{
		List,
		Board
	}

    /// <summary>
    /// Helper class for managing <see href="https://todoist.com/help/articles/manage-your-view">Todoist View Styles</see>.
    /// </summary>
    public static class TodoistViewStylesUtils
    {
        /// <summary>
        /// Get the view style name as expected in the Todoist API.
        /// </summary>
        /// <param name="viewStyle"><see cref="TodoistViewStyles"/> enum value.</param>
        /// <returns>Name of the view style.</returns>
        /// <exception cref="InvalidKeyException"></exception>
        public static string? GetViewStyleKey(TodoistViewStyles? viewStyle)
        {
            if (viewStyle == null)
            {
                return null;
            }

            return viewStyle switch
            {
                TodoistViewStyles.List => "list",
                TodoistViewStyles.Board => "board",
                _ => throw new InvalidKeyException("Unsupported view style.")
            };
        }

        /// <summary>
        /// Get an <see cref="TodoistViewStyles"/> enum value from the provided view style name.
        /// </summary>
        /// <param name="viewStyleName">The name of the view style.</param>
        /// <returns>A <see cref="TodoistViewStyles"/> enum value.</returns>
        /// <exception cref="InvalidKeyException"></exception>
        public static TodoistViewStyles GetViewStyle(string viewStyleName)
        {
            return viewStyleName switch
            {
                "list" => TodoistViewStyles.List,
                "board" => TodoistViewStyles.Board,
                _ => throw new InvalidKeyException("Unsupported view style.")
            };
        }
    }
}

