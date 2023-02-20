using System;
using CoderBash.Net.Todoist.Common.Enums;

namespace CoderBash.Net.Todoist.Tests.CommonTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Enums",
		Description = "Todoist Task Priorities enum tests",
		TestOf = typeof(TodoistTaskPriorities))]
	public class TodoistTaskPrioritiesTests
	{
		[Test(
			Author = "Demarbit BV",
			Description = "Test get filter label")]
		public void Test_Common_TodoistTaskPriorities_GetFilterLabels()
		{
			Assert.Multiple(() =>
			{
                Assert.That(TodoistTaskPrioritiesUtils.GetFilterLabel(TodoistTaskPriorities.None), Is.EqualTo(""));
                Assert.That(TodoistTaskPrioritiesUtils.GetFilterLabel(TodoistTaskPriorities.P1), Is.EqualTo("p1"));
                Assert.That(TodoistTaskPrioritiesUtils.GetFilterLabel(TodoistTaskPriorities.P2), Is.EqualTo("p2"));
                Assert.That(TodoistTaskPrioritiesUtils.GetFilterLabel(TodoistTaskPriorities.P3), Is.EqualTo("p3"));
            });
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test get priority from value")]
		public void Test_Common_TodoistTaskPriorities_GetPriorityFromValues()
		{
			Assert.Multiple(() =>
			{
				Assert.That(TodoistTaskPrioritiesUtils.GetFromValue(1), Is.EqualTo(TodoistTaskPriorities.None));
                Assert.That(TodoistTaskPrioritiesUtils.GetFromValue(2), Is.EqualTo(TodoistTaskPriorities.P3));
                Assert.That(TodoistTaskPrioritiesUtils.GetFromValue(3), Is.EqualTo(TodoistTaskPriorities.P2));
                Assert.That(TodoistTaskPrioritiesUtils.GetFromValue(4), Is.EqualTo(TodoistTaskPriorities.P1));
            });
		}
	}
}

