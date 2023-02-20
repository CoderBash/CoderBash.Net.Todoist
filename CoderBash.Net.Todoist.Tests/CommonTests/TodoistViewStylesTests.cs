using System;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Exceptions;

namespace CoderBash.Net.Todoist.Tests.CommonTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Enums",
		Description = "Todoist View Styles enum tests",
		TestOf = typeof(TodoistViewStyles))]
	public class TodoistViewStylesTests
	{
		[Test(
			Author = "Demarbit BV",
			Description = "Test Get View Style Key")]
		public void Test_Common_TodoistViewStyles_GetKeys()
		{
			Assert.Multiple(() =>
			{
				Assert.That(TodoistViewStylesUtils.GetViewStyleKey(TodoistViewStyles.Board), Is.EqualTo("board"));
				Assert.That(TodoistViewStylesUtils.GetViewStyleKey(TodoistViewStyles.List), Is.EqualTo("list"));
				Assert.That(TodoistViewStylesUtils.GetViewStyleKey(null), Is.Null);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test Get Invalid View Style Key")]
		public void Test_Common_TodoistViewStyles_GetInvalidKey()
		{
			Assert.Throws<InvalidKeyException>(() =>
			{
				TodoistViewStylesUtils.GetViewStyleKey((TodoistViewStyles)100);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get View Styles test")]
		public void Test_Common_TodoistViewStyles_GetViewStyles()
		{
			Assert.Multiple(() =>
			{
                Assert.That(TodoistViewStylesUtils.GetViewStyle("list"), Is.EqualTo(TodoistViewStyles.List));
                Assert.That(TodoistViewStylesUtils.GetViewStyle("board"), Is.EqualTo(TodoistViewStyles.Board));
            });
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get Invalid View Styles test")]
		public void Test_Common_TodoistViewStyles_GetViewStylesInvalid()
		{
			Assert.Throws<InvalidKeyException>(() =>
			{
				TodoistViewStylesUtils.GetViewStyle("invalid");
			});
		}
	}
}

