using System;
using CoderBash.Net.Todoist.Common.Options;

namespace CoderBash.Net.Todoist.Tests.Constants
{
	public static class TodoistConfiguration
	{
		private static TodoistOptions options = new TodoistOptions
		{
			ApiToken = Environment.GetEnvironmentVariable("CoderBashTodoistApiToken") ?? ""
		};

		public static string GetApiToken()
		{
			return options.ApiToken;
		}

		public static string GetTestProjectId()
		{
			return "2308184561";
		}

		public static string GetTestSectionId()
		{
			return "116070283";
        }

		public static string GetTestTaskId()
		{
			return "6628775296";
        }

		public static string GetTestLabelId()
		{
			return "2165161967";
        }

		public static string GetTestLabelName()
		{
			return "test-label";
		}
	}
}

