using System;
namespace CoderBash.Net.Todoist.Rest.Models.Comments
{
	/// <summary>
	/// Model for updating an existing <see cref="TodoistComment">Todoist Comment</see>.
	/// </summary>
	public class UpdateTodoistCommentModel
	{
        /// <summary>
        /// Comment content. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
        /// </summary>
        public string Content { get; set; } = null!;
    }
}

