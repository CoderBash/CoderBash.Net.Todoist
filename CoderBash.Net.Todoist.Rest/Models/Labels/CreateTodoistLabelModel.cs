using System;
using CoderBash.Net.Todoist.Common.Enums;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Models.Labels
{
	/// <summary>
	/// Model for creating a new <see cref="TodoistLabel">Todoist Label</see>.
	/// </summary>
	public class CreateTodoistLabelModel
	{
		/// <summary>
		/// Name of the label.
		/// </summary>
		public string Name { get; set; } = null!;

		/// <summary>
		/// [Optional] Label order.
		/// </summary>
		public int? Order { get; set; } = null;

		/// <summary>
		/// [Optional] The color of the label icon. See <see cref="TodoistColors"/> for available options.
		/// </summary>
		public TodoistColors? Color { get; set; } = null;

		/// <summary>
		/// [Optional] Whether the label is a favorite.
		/// </summary>
		public bool? IsFavorite { get; set; } = null;
	}
}

