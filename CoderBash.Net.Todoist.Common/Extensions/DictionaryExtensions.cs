using System;
namespace CoderBash.Net.Todoist.Common.Extensions
{
	public static class DictionaryExtensions
	{
		/// <summary>
		/// Add a new key-value pair to the dictionary. The value will only be added in the following cases:
		/// <br> - The value is not null and the dictionary did not yet contain the specified key</br>
		/// <br> - The value is not null and the dictionary did contain the specified key but <paramref name="allowValueOverwrite"/> is <c>true</c></br>
		/// </summary>
		/// <param name="dictionary">The source directory</param>
		/// <param name="key">The key for the new key-value pair</param>
		/// <param name="value">The value for the new key-value pair</param>
		/// <param name="allowValueOverwrite">Enables/disables value overwrite if key already exists.</param>
		public static void TryAddValue(this Dictionary<string, object> dictionary, string key, object? value, bool allowValueOverwrite = false)
		{
			if (value == null)
			{
				return;
			}

			if (dictionary.ContainsKey(key))
			{
				if (allowValueOverwrite)
				{
					dictionary[key] = value;
				}
			} else
			{
				dictionary.Add(key, value);
			}
		}
	}
}

