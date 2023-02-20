using System;
namespace CoderBash.Net.Todoist.Rest.Models.Comments
{
	/// <summary>
	/// Model for creating a new <see cref="TodoistComment">Todoist Comment</see>
	/// </summary>
	public class CreateTodoistCommentModel
	{
		/// <summary>
		/// The ID of the comment's parent. Depending on the endpoint used this will either be a <c>taskId</c> or a <c>projectId</c>.
		/// </summary>
		public string ParentId { get; set; } = null!;

		/// <summary>
		/// Comment content. This value may contain markdown-formatted text and hyperlinks. Details on markdown support can be found in the <see href="https://todoist.com/help/articles/205195102">Text Formatting article</see> in the Help Center.
		/// </summary>
		public string Content { get; set; } = null!;

		// TODO attachment
	}
}

