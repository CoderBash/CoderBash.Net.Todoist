using CoderBash.Net.Todoist.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Common.Enums
{
    /// <summary>
    /// Todoist Collaborator States. See <see href="https://developer.todoist.com/sync/v9/#collaborator-states">Collaborator States</see> for more information.
    /// </summary>
    public enum TodoistCollaborationState
    {
        Active,
        Invited
    }

    /// <summary>
    /// Helper class for managing <see cref="TodoistCollaborationState"/> values.
    /// </summary>
    public static class TodoistCollaborationStateUtils
    {
        /// <summary>
        /// Gets the unique name of the collaborator state. To be used when using the API.
        /// </summary>
        /// <param name="state">A <see cref="TodoistCollaborationState"/> enum value</param>
        /// <returns>Todoist state key or null if invalid value was defined.</returns>
        public static string? GetStateKey(TodoistCollaborationState? state)
        {
            if (state == null) return null;

            return state switch
            {
                TodoistCollaborationState.Active => "active",
                TodoistCollaborationState.Invited => "invited",
                _ => null
            };
        }

        public static TodoistCollaborationState GetFromName(string stateName)
        {
            return stateName.ToLower() switch
            {
                "active" => TodoistCollaborationState.Active,
                "invited" => TodoistCollaborationState.Invited,
                _ => throw new InvalidKeyException($"Invalid collaboration state key '{stateName}' provided.")
            };
        }
    }
}
