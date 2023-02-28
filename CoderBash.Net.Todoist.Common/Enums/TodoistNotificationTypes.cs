using CoderBash.Net.Todoist.Common.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Common.Enums
{
    /// <summary>
    /// Todoist Notification Types. See <see href="https://developer.todoist.com/sync/v9/#live-notifications">Todoist Live Notifications</see> for more information.
    /// </summary>
    public enum TodoistNotificationTypes
    {
        ShareInvitationSent,
        ShareInvitationAccepted,
        ShareInvitationRejected,
        UserLeftProject,
        UserRemovedFromProject,
        ItemAssigned,
        ItemCompleted,
        ItemUncompleted,
        NoteAdded,
        BizPolicyDisallowedInvitation,
        BizPolicyRejectedInvitation,
        BizTrialWillEnd,
        BizPaymentFailed,
        BizAccountDisabled,
        BizInvitationCreated,
        BizInvitationAccepted,
        BizInvitationRejected,
        DailyGoalReached,
        WeeklyGoalReached
    }

    /// <summary>
    /// Helper class for managing <see cref="TodoistNotificationTypes"/> enum values.
    /// </summary>
    public static class TodoistNotificationTypesUtils
    {
        /// <summary>
        /// Get the notification type key as defined in <see href="https://developer.todoist.com/sync/v9/#live-notifications">Todoist Live Notifications</see>.
        /// </summary>
        /// <param name="type">A <see cref="TodoistNotificationTypes"/> enum value.</param>
        /// <returns>The notification type key used by the API.</returns>
        public static string? GetTypeKey(TodoistNotificationTypes? type)
        {
            if (type == null) return null;

            return type switch
            {
                TodoistNotificationTypes.ShareInvitationSent => "share_invitation_sent",
                TodoistNotificationTypes.ShareInvitationAccepted => "share_invitation_accepted",
                TodoistNotificationTypes.ShareInvitationRejected => "share_invitation_rejected",
                TodoistNotificationTypes.UserLeftProject => "user_left_project",
                TodoistNotificationTypes.UserRemovedFromProject => "user_removed_from_project",
                TodoistNotificationTypes.ItemAssigned => "item_assigned",
                TodoistNotificationTypes.ItemCompleted => "item_completed",
                TodoistNotificationTypes.ItemUncompleted => "item_uncompleted",
                TodoistNotificationTypes.NoteAdded => "note_added",
                TodoistNotificationTypes.BizPolicyDisallowedInvitation => "biz_policy_disallowed_invitation",
                TodoistNotificationTypes.BizPolicyRejectedInvitation => "biz_policy_rejected_invitation",
                TodoistNotificationTypes.BizTrialWillEnd => "biz_trial_will_end",
                TodoistNotificationTypes.BizPaymentFailed => "biz_payment_failed",
                TodoistNotificationTypes.BizAccountDisabled => "biz_account_disabled",
                TodoistNotificationTypes.BizInvitationCreated => "biz_invitation_created",
                TodoistNotificationTypes.BizInvitationAccepted => "biz_invitation_accepted",
                TodoistNotificationTypes.BizInvitationRejected => "biz_invitation_rejected",
                TodoistNotificationTypes.DailyGoalReached => "daily_goal_reached",
                TodoistNotificationTypes.WeeklyGoalReached => "weekly_goal_reached",
                _ => null
            };
        }

        /// <summary>
        /// Get a <see cref="TodoistNotificationTypes"/> value from the notification type key used in the Todoist API.
        /// </summary>
        /// <param name="typeKey">A notification type key as found in <see href="https://developer.todoist.com/sync/v9/#live-notifications">Todoist Live Notifications</see>.</param>
        /// <returns>A <see cref="TodoistNotificationTypes"/> enum value.</returns>
        /// <exception cref="InvalidKeyException"></exception>
        public static TodoistNotificationTypes GetTypeFromKey(string typeKey)
        {
            return typeKey.ToLower() switch
            {
                "share_invitation_sent" => TodoistNotificationTypes.ShareInvitationSent,
                "share_invitation_accepted" => TodoistNotificationTypes.ShareInvitationAccepted,
                "share_invitation_rejected" => TodoistNotificationTypes.ShareInvitationRejected,
                "user_left_project" => TodoistNotificationTypes.UserLeftProject,        
                "user_removed_from_project" => TodoistNotificationTypes.UserRemovedFromProject,
                "item_assigned" => TodoistNotificationTypes.ItemAssigned,
                "item_completed" => TodoistNotificationTypes.ItemCompleted,
                "item_uncompleted" => TodoistNotificationTypes.ItemUncompleted,
                "note_added" => TodoistNotificationTypes.NoteAdded,
                "biz_policy_disallowed_invitation" => TodoistNotificationTypes.BizPolicyDisallowedInvitation,
                "biz_policy_rejected_invitation" => TodoistNotificationTypes.BizPolicyRejectedInvitation,   
                "biz_trial_will_end" => TodoistNotificationTypes.BizTrialWillEnd,
                "biz_payment_failed" => TodoistNotificationTypes.BizPaymentFailed,
                "biz_account_disabled" => TodoistNotificationTypes.BizAccountDisabled,
                "biz_invitation_created" => TodoistNotificationTypes.BizInvitationCreated,
                "biz_invitation_accepted" => TodoistNotificationTypes.BizInvitationAccepted,
                "biz_invitation_rejected" => TodoistNotificationTypes.BizInvitationRejected,
                "daily_goal_reached" => TodoistNotificationTypes.DailyGoalReached,
                "weekly_goal_reached" => TodoistNotificationTypes.WeeklyGoalReached,
                _ => throw new InvalidKeyException($"Invalid notification type key '{typeKey}' provided.")
            };
        }
    }
}
