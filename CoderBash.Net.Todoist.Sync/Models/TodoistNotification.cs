using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist Notification model for the Sync API.
    /// </summary>
    public class TodoistNotification
    {
        // Common properties
        /// <summary>
        /// The ID of the notification.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// Live notification creation date.
        /// </summary>
        [JsonProperty("created_at")]
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// The ID of the user who initiated this live notification.
        /// </summary>
        [JsonProperty("from_uid")]
        public string FromUserId { get; set; } = null!;

        /// <summary>
        /// Unique notification key.
        /// </summary>
        [JsonProperty("notification_key")]
        public string NotificationKey { get; set; } = null!;

        /// <summary>
        /// The type of notification. See <see cref="Common.Enums.TodoistNotificationTypes"/> for available options.
        /// </summary>
        [JsonProperty("notification_type")]
        public string NotificationType { get; set; } = null!;

        /// <summary>
        /// Notification sequence number.
        /// </summary>
        [JsonProperty("seq_no")]
        public int SequenceNumber { get; set; }

        /// <summary>
        /// Whether the notification is marked as unread.
        /// </summary>
        [JsonProperty("is_unread")]
        public bool IsUnread { get; set; }

        // *_invitation_* properties
        /// <summary>
        /// User data linked to an invitation notification.
        /// <para>
        /// Only available on *_invitation_* notification types.
        /// </para>
        /// </summary>
        [JsonProperty("from_user")]
        public TodoistNotificationUser? FromUser { get; set; }

        /// <summary>
        /// The project name for an invitation notification
        /// <para>
        /// Only available on *_invitation_* notification types.
        /// </para>
        /// </summary>
        [JsonProperty("project_name")]
        public string? ProjectName { get; set; }

        /// <summary>
        /// The invitation ID for an invitation notification.
        /// <para>
        /// Only available on *_invitation_* notification types.
        /// </para>
        /// </summary>
        [JsonProperty("invitation_id")]
        public string? InvitationId { get; set; }

        /// <summary>
        /// The invitation secret key for an invitation notification.
        /// <para>
        /// Only available on *_invitation_* notification types.
        /// </para>
        /// </summary>
        [JsonProperty("invitation_secret")]
        public string? InvitationSecret { get; set; }

        // share_invitation_sent properties
        /// <summary>
        /// Invitation state for share_invitation_sent notifications. Initially <c>invited</c>, can be changed to <c>accepted</c> or <c>rejected</c>
        /// <para>
        /// Only available on the share_invitation_sent and biz_invitation_created notifications.
        /// </para>
        /// </summary>
        [JsonProperty("state")]
        public string? InvitationState { get; set; }

        // user_removed_from_project properties
        /// <summary>
        /// The name of the removed user.
        /// <para>
        /// Only available on the user_removed_from_project notification.
        /// </para>
        /// </summary>
        [JsonProperty("removed_name")]
        public string? RemovedName { get; set; }

        /// <summary>
        /// The ID of the removed user.
        /// <para>
        /// Only available on the user_removed_from_project notification.
        /// </para>
        /// </summary>
        [JsonProperty("removed_uid")]
        public string? RemovedUserId { get; set; }

        // biz_* properties
        /// <summary>
        /// The number of users under control of the business account.
        /// <para>
        /// Only available on the biz_trial_will_end, biz_pyament_failed and biz_account_disabled notifications.
        /// </para>
        /// </summary>
        [JsonProperty("quantity")]
        public int? BusinessPlanNumberOfUsers { get; set; }

        /// <summary>
        /// Tariff plan name. Valid values are <c>business_monthly</c> and <c>business_yearly</c>.
        /// <para>
        /// Only available on the biz_trial_will_end, biz_pyament_failed and biz_account_disabled notifications.
        /// </para>
        /// </summary>
        [JsonProperty("plan")]
        public string? BusinessPlan { get; set; }

        /// <summary>
        /// The timestamp when the business account will be disabled.
        /// <para>
        /// Only available on the biz_trial_will_end, biz_pyament_failed and biz_account_disabled notifications.
        /// </para>
        /// </summary>
        [JsonProperty("active_until")]
        public int? BusinessPlanActiveUntil { get; set; }

        // biz_payment_failed properties
        /// <summary>
        /// Invoice amount. Integer value in <c>0.01</c> of currency.
        /// <para>
        /// Only available on the biz_payment_failed notification.
        /// </para>
        /// </summary>
        [JsonProperty("amount_due")]
        public int? AmountDue { get; set; }

        /// <summary>
        /// Number of automatic payment attempts made for this invoice.
        /// <para>
        /// Only available on the biz_payment_failed notification.
        /// </para>
        /// </summary>
        [JsonProperty("attempt_count")]
        public int? AttemptCount { get; set; }

        /// <summary>
        /// Currency value. Three-letter ISO currency code representing the currency in which the charge was made.
        /// <para>
        /// Only available on the biz_payment_failed notification.
        /// </para>
        /// </summary>
        [JsonProperty("currency")]
        public string? Currency { get; set; }

        /// <summary>
        /// Invoice description.
        /// <para>
        /// Only available on the biz_payment_failed notification.
        /// </para>
        /// </summary>
        [JsonProperty("description")]
        public string? InvoiceDescription { get; set; }

        /// <summary>
        /// Timestamp value of when the next automatic payment attempt will occur.
        /// <para>
        /// Only available on the biz_payment_failed notification.
        /// </para>
        /// </summary>
        [JsonProperty("next_payment_attempt")]
        public int? NextPaymentAttempt { get; set; }

        // biz_invitation_created
        /// <summary>
        /// Invitation message.
        /// <para>
        /// Only available on the biz_invitation_created notification.
        /// </para>
        /// </summary>
        [JsonProperty("invitation_message")]
        public string? InvitationMessage { get; set; }

        /// <summary>
        /// Business account (company) name.
        /// <para>
        /// Only available on the biz_invitation_created notification.
        /// </para>
        /// </summary>
        [JsonProperty("account_name")]
        public string? AccountName { get; set; }
    }
}
