using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Sync.Models
{
    /// <summary>
    /// Todoist User model for the Sync API.
    /// </summary>
    public class TodoistUser
    {
        /// <summary>
        /// The default time in minutes for the automatic reminders set, whenever a due date has been specified for a task.
        /// </summary>
        [JsonProperty("auto_reminder")]
        public int AutoReminder { get; set; }

        /// <summary>
        /// The link to a 195x195 pixels image of the user's avatar.
        /// </summary>
        [JsonProperty("avatar_big")]
        public string AvatarBig { get; set; } = null!;

        /// <summary>
        /// The link to a 60x60 pixels image of the user's avatar.
        /// </summary>
        [JsonProperty("avatar_medium")]
        public string AvatarMedium { get; set; } = null!;

        /// <summary>
        /// The link to a 640x640 pixels image of the user's avatar.
        /// </summary>
        [JsonProperty("avatar_s640")]
        public string Avatar { get; set; } = null!;

        /// <summary>
        /// The link to a 35x35 pixels image of the user's avatar.
        /// </summary>
        [JsonProperty("avatar_small")]
        public string AvatarSmall { get; set; } = null!;

        /// <summary>
        /// The ID of the user's business account.
        /// </summary>
        [JsonProperty("business_account_id")]
        public string BusinessAccountId { get; set; } = null!;

        /// <summary>
        /// The daily goal number of completed tasks for karma.
        /// </summary>
        [JsonProperty("daily_goal")]
        public int DailyGoal { get; set; }

        /// <summary>
        /// Whether to use the 'DD-MM-YYYY' date format (if set to <c>0</c>), or the 'MM-DD-YYYY' date format (if set to <c>1</c>).
        /// </summary>
        [JsonProperty("date_format")]
        public int DateFormat { get; set; }

        /// <summary>
        /// Whether smart date recognition has been disabled.
        /// </summary>
        [JsonProperty("dateist_inline_disabled")]
        public bool IsDateistInlineDisabled { get; set; }

        /// <summary>
        /// The language expected for date recognition instead of the user's <see cref="Language"/>. See <see cref="Common.Enums.TodoistLanguages"/> for available options.
        /// </summary>
        [JsonProperty("dateist_lang")]
        public string DateistLanguage { get; set; } = null!;

        /// <summary>
        /// Array of integers representing the user's days off (between <c>1</c> and <c>7</c>, where <c>1</c> is Monday and <c>7</c> is Sunday).
        /// </summary>
        [JsonProperty("days_off")]
        public int[] DaysOff { get; set; } = null!;

        /// <summary>
        /// The user's email address.
        /// </summary>
        [JsonProperty("email")]
        public string Email { get; set; } = null!;

        // TODO features property

        /// <summary>
        /// The user's full name.
        /// </summary>
        [JsonProperty("full_name")]
        public string FullName { get; set; } = null!;

        /// <summary>
        /// Whether the user has a password set on the account. It will be <c>false</c> if they have only authenticated with a password (e.g. Google, Facebook, ...).
        /// </summary>
        [JsonProperty("has_password")]
        public bool HasPassword { get; set; }

        /// <summary>
        /// The ID of the user.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; } = null!;

        /// <summary>
        /// The ID of the user's avatar.
        /// </summary>
        [JsonProperty("image_id")]
        public string ImageId { get; set; } = null!;

        /// <summary>
        /// The ID of the user's inbox project.
        /// </summary>
        [JsonProperty("inbox_project_id")]
        public string InboxProjectId { get; set; } = null!;

        /// <summary>
        /// Whether the user is a business account administrator.
        /// </summary>
        [JsonProperty("is_biz_admin")]
        public bool IsBusinessAdmin { get; set; }

        /// <summary>
        /// Whether the user has a Todoist Pro subscription.
        /// </summary>
        [JsonProperty("is_premium")]
        public bool IsPremium { get; set; }

        /// <summary>
        /// The date when the user joined Todoist.
        /// </summary>
        [JsonProperty("joined_at")]
        public DateTime JoinedAt { get; set; }

        /// <summary>
        /// The user's karma score.
        /// </summary>
        [JsonProperty("karma")]
        public int Karma { get; set; }

        /// <summary>
        /// The user's karma trend (for example <c>up</c>).
        /// </summary>
        [JsonProperty("karma_trend")]
        public string KarmaTrend { get; set; } = null!;

        /// <summary>
        /// The user's language. See <see cref="Common.Enums.TodoistLanguages"/> for available options.
        /// </summary>
        [JsonProperty("lang")]
        public string Language { get; set; } = null!;

        /// <summary>
        /// The day of the next week that tasks will be postponed to (between <c>1</c> and <c>7</c>, where <c>1</c> is Monday and <c>7</c> is Sunday).
        /// </summary>
        [JsonProperty("next_week")]
        public int NextWeekDay { get; set; }

        /// <summary>
        /// The date when the user's Todoist Pro subscription ends (null if not a Todoist Pro user).
        /// </summary>
        [JsonProperty("premium_until")]
        public DateTime? PremiumUntil { get; set; }

        /// <summary>
        /// Whether to show projects in an oldest dates first (if set to <c>0</c>) or a oldest dates last order (if set to <c>1</c>).
        /// </summary>
        [JsonProperty("sort_order")]
        public int SortOrder { get; set; }

        /// <summary>
        /// The first day of the week (between <c>1</c> and <c>7</c>, where <c>1</c> is Monday and <c>7</c> is Sunday).
        /// </summary>
        [JsonProperty("start_day")]
        public int FirstDayOfWeek { get; set; }

        /// <summary>
        /// The user's default view on Todoist. The start page can be one of the following:
        /// <list type="bullet">
        ///     <item>
        ///         <term>inbox</term>
        ///         <description>Opens the user's Inbox project.</description>
        ///     </item>
        ///     <item>
        ///         <term>teaminbox</term>
        ///         <description>Opens the user's Team Inbox project.</description>
        ///     </item>
        ///     <item>
        ///         <term>today</term>
        ///         <description>Opens the user's Today view.</description>
        ///     </item>
        ///     <item>
        ///         <term>next7days</term>
        ///         <description>Opens the user's Next 7 Days view.</description>
        ///     </item>
        ///     <item>
        ///         <term>project?id=1234</term>
        ///         <description>Opens a specific project with the specified id.</description>
        ///     </item>
        ///     <item>
        ///         <term>label?name=abc</term>
        ///         <description>Opens the Label view for the specified label.</description>
        ///     </item>
        ///     <item>
        ///         <term>filter?id=1234</term>
        ///         <description>Opens the Filter view for the specified filter.</description>
        ///     </item>
        /// </list>
        /// </summary>
        [JsonProperty("start_page")]
        public string StartPage { get; set; } = null!;

        /// <summary>
        /// The ID of the Team Inbox project.
        /// </summary>
        [JsonProperty("team_inbox_id")]
        public string? TeamInboxId { get; set; }

        /// <summary>
        /// the currently selected Todoist theme (a number between <c>0</c> and <c>10</c>).
        /// </summary>
        [JsonProperty("theme_id")]
        public string ThemeId { get; set; } = null!;

        /// <summary>
        /// Whether to use a <c>24h</c> format such as 13:00 (if set to <c>0</c>) when displaying time, or a <c>12h</c> format sub as 1:00pm (if set to <c>1</c>).
        /// </summary>
        [JsonProperty("time_format")]
        public int Timeformat { get; set; }

        /// <summary>
        /// The user's token that should be used to call the other API methods.
        /// </summary>
        [JsonProperty("token")]
        public string? Token { get; set; }

        // TODO tz_object property

        /// <summary>
        /// The day used when a user chooses to schedule a task for the 'Weekend' (between <c>1</c> and <c>7</c>, where <c>1</c> is Monday and <c>7</c> is Sunday).
        /// </summary>
        [JsonProperty("weekend_start_day")]
        public int FirstDayOfWeekend { get; set; }

        /// <summary>
        /// Describes if the user has verified their email address or not. Possible values are:
        /// <list type="bullet">
        ///     <item>
        ///         <term>unverified</term>
        ///         <description>for users that have just signed up. Those users cannot use any of Todoist's social features like sharing projects or accepting project invitations.</description>
        ///     </item>
        ///     <item>
        ///         <term>verify</term>
        ///         <description>for users that have verified themselves somehow. Clicking on the verification link inside the account confirmation e-mail is one such way alongside signing up through a social account.</description>
        ///     </item>
        ///     <item>
        ///         <term>blocked</term>
        ///         <description> for users that have failed to verify themselves in 7 days. Those users will have restricted usage of Todoist.</description>
        ///     </item>
        ///     <item>
        ///         <term>legacy</term>
        ///         <description>for users that have signed up before August, 2022 weekly_goal Integer | The target number of tasks to complete per week.</description>
        ///     </item>
        ///     
        /// </list>
        /// </summary>
        [JsonProperty("verification_status")]
        public string VerificationStatus { get; set; } = null!;
    }
}
