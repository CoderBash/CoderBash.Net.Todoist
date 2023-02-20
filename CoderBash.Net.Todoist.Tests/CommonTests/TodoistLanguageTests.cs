using System;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Exceptions;

namespace CoderBash.Net.Todoist.Tests.CommonTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Enums",
		Description = "Todoist Language enums tests",
		TestOf = typeof(TodoistLanguages)
		)]
	public class TodoistLanguageTests
	{
		[Test(
			Author = "Demarbit BV",
			Description = "Get Language Keys test")]
		public void Test_Common_TodoistLanguages_GetLanguageKeys()
		{
			Assert.Multiple(() =>
			{
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Chinese), Is.EqualTo("zh"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Czech), Is.EqualTo("cs"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Danish), Is.EqualTo("da"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Dutch), Is.EqualTo("nl"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.English), Is.EqualTo("en"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Finnish), Is.EqualTo("fi"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.French), Is.EqualTo("fr"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.German), Is.EqualTo("de"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Italian), Is.EqualTo("it"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Japanese), Is.EqualTo("ja"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Korean), Is.EqualTo("ko"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Norwegian), Is.EqualTo("nb"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Polish), Is.EqualTo("pl"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Portugese), Is.EqualTo("pt"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Russian), Is.EqualTo("ru"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Spanish), Is.EqualTo("es"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Swedish), Is.EqualTo("sv"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(TodoistLanguages.Turkish), Is.EqualTo("tr"));
                Assert.That(TodoistLanguagesUtils.GetLanguageKey(null), Is.Null);
            });
		}

        [Test(
            Author = "Demarbit BV",
            Description = "Get Invalid Language Keys test")]
        public void Test_Common_TodoistLanguages_GetInvalidLanguageKeys()
        {
            Assert.Throws<InvalidKeyException>(() =>
            {
                TodoistLanguagesUtils.GetLanguageKey((TodoistLanguages)100);
            });
        }

        [Test(
            Author = "Demarbit BV",
            Description = "Get Language From Keys test")]
        public void Test_Common_TodoistLanguages_GetLanguageFromKeys()
        {
            Assert.Multiple(() =>
            {
                Assert.That(TodoistLanguagesUtils.GetFromKey("zh"), Is.EqualTo(TodoistLanguages.Chinese));
                Assert.That(TodoistLanguagesUtils.GetFromKey("cs"), Is.EqualTo(TodoistLanguages.Czech));
                Assert.That(TodoistLanguagesUtils.GetFromKey("da"), Is.EqualTo(TodoistLanguages.Danish));
                Assert.That(TodoistLanguagesUtils.GetFromKey("nl"), Is.EqualTo(TodoistLanguages.Dutch));
                Assert.That(TodoistLanguagesUtils.GetFromKey("en"), Is.EqualTo(TodoistLanguages.English));
                Assert.That(TodoistLanguagesUtils.GetFromKey("fi"), Is.EqualTo(TodoistLanguages.Finnish));
                Assert.That(TodoistLanguagesUtils.GetFromKey("fr"), Is.EqualTo(TodoistLanguages.French));
                Assert.That(TodoistLanguagesUtils.GetFromKey("de"), Is.EqualTo(TodoistLanguages.German));
                Assert.That(TodoistLanguagesUtils.GetFromKey("it"), Is.EqualTo(TodoistLanguages.Italian));
                Assert.That(TodoistLanguagesUtils.GetFromKey("ja"), Is.EqualTo(TodoistLanguages.Japanese));
                Assert.That(TodoistLanguagesUtils.GetFromKey("ko"), Is.EqualTo(TodoistLanguages.Korean));
                Assert.That(TodoistLanguagesUtils.GetFromKey("nb"), Is.EqualTo(TodoistLanguages.Norwegian));
                Assert.That(TodoistLanguagesUtils.GetFromKey("pl"), Is.EqualTo(TodoistLanguages.Polish));
                Assert.That(TodoistLanguagesUtils.GetFromKey("pt"), Is.EqualTo(TodoistLanguages.Portugese));
                Assert.That(TodoistLanguagesUtils.GetFromKey("ru"), Is.EqualTo(TodoistLanguages.Russian));
                Assert.That(TodoistLanguagesUtils.GetFromKey("es"), Is.EqualTo(TodoistLanguages.Spanish));
                Assert.That(TodoistLanguagesUtils.GetFromKey("sv"), Is.EqualTo(TodoistLanguages.Swedish));
                Assert.That(TodoistLanguagesUtils.GetFromKey("tr"), Is.EqualTo(TodoistLanguages.Turkish));
            });
        }

        [Test(
            Author = "Demarbit BV",
            Description = "Get Language from Invalid Key test")]
        public void Test_Common_TodoistLanguages_GetLanguageFromInvalidKey()
        {
            Assert.Throws<InvalidKeyException>(() =>
            {
                TodoistLanguagesUtils.GetFromKey("invalid");
            });
        }
	}
}

