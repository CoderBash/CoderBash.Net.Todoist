using System;
using CoderBash.Net.Todoist.Common.Exceptions;

namespace CoderBash.Net.Todoist.Common.Enums
{
	public enum TodoistLanguages
    {
        Chinese,
        Czech,
        Danish,
        Dutch,
        English,
        Finnish,
        French,
        German,
        Italian,
        Japanese,
        Korean,
        Norwegian,
        Polish,
        Portugese,
        Russian,
        Spanish,
        Swedish,
		Turkish
	}

    public static class TodoistLanguagesUtils
    {
        public static string? GetLanguageKey(TodoistLanguages? language)
        {
            if (language == null)
            {
                return null;
            }

            return language switch
            {
                TodoistLanguages.Chinese => "zh",
                TodoistLanguages.Czech => "cs",
                TodoistLanguages.Danish => "da",
                TodoistLanguages.Dutch => "nl",
                TodoistLanguages.English => "en",
                TodoistLanguages.Finnish => "fi",
                TodoistLanguages.French => "fr",
                TodoistLanguages.German => "de",
                TodoistLanguages.Italian => "it",
                TodoistLanguages.Japanese => "ja",
                TodoistLanguages.Korean => "ko",
                TodoistLanguages.Norwegian => "nb",
                TodoistLanguages.Polish => "pl",
                TodoistLanguages.Portugese => "pt",
                TodoistLanguages.Russian => "ru",
                TodoistLanguages.Spanish => "es",
                TodoistLanguages.Swedish => "sv",
                TodoistLanguages.Turkish => "tr",
                _ => throw new InvalidKeyException("Unsupported language provided.")
            };
        }

        public static TodoistLanguages GetFromKey(string languageKey)
        {
            return languageKey.ToLower() switch
            {
                "zh" => TodoistLanguages.Chinese,
                "cs" => TodoistLanguages.Czech,
                "da" => TodoistLanguages.Danish,
                "nl" => TodoistLanguages.Dutch,
                "en" => TodoistLanguages.English,
                "fi" => TodoistLanguages.Finnish,
                "fr" => TodoistLanguages.French,
                "de" => TodoistLanguages.German,
                "it" => TodoistLanguages.Italian,
                "ja" => TodoistLanguages.Japanese,
                "ko" => TodoistLanguages.Korean,
                "nb" => TodoistLanguages.Norwegian,
                "pl" => TodoistLanguages.Polish,
                "pt" => TodoistLanguages.Portugese,
                "ru" => TodoistLanguages.Russian,
                "es" => TodoistLanguages.Spanish,
                "sv" => TodoistLanguages.Swedish,
                "tr" => TodoistLanguages.Turkish,
                _ => throw new InvalidKeyException("Unsupported language provided.")
            };
        }
    }
}

