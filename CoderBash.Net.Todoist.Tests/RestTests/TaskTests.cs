using System;
using System.Security.Cryptography.X509Certificates;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Exceptions;
using CoderBash.Net.Todoist.Rest.Client;
using CoderBash.Net.Todoist.Rest.Models.Tasks;
using CoderBash.Net.Todoist.Tests.Constants;

namespace CoderBash.Net.Todoist.Tests.RestTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Rest.Tasks",
		Description = "Tasks REST endpoint tests",
		TestOf = typeof(TodoistClient))]
	public class TaskTests
	{
		private readonly string TEST_PROJECT_ID = TodoistConfiguration.GetTestProjectId();
		private readonly string TEST_SECTION_ID = TodoistConfiguration.GetTestSectionId();
		private readonly string TEST_TASK_ID = TodoistConfiguration.GetTestTaskId();
		private readonly string TEST_LABEL_NAME = TodoistConfiguration.GetTestLabelName();

		private TodoistClient _client;

		[OneTimeSetUp]
		public void FixtureSetup()
		{
			_client = new TodoistClient(TodoistConfiguration.GetApiToken());
		}

		[OneTimeTearDown]
		public void FixtureTearDown()
		{
			_client?.Dispose();
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get All Active Tasks (unfiltered)")]
		public void Test_Rest_Tasks_FetchActive()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var tasks = await _client.GetActiveTasksAsync();

				Assert.Multiple(() =>
				{
					Assert.That(tasks, Is.Not.Null);
					Assert.That(tasks, Has.Count.GreaterThan(0));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get All Active Tasks for project")]
		public void Test_Rest_Tasks_FetchActiveForProject()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var tasks = await _client.GetActiveTasksForProjectAsync(TEST_PROJECT_ID);

				Assert.Multiple(() =>
				{
					Assert.That(tasks, Is.Not.Null);
					Assert.That(tasks, Has.Count.GreaterThan(0));
					Assert.That(tasks.Any(task => task.ProjectId != TEST_PROJECT_ID), Is.False);
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get All Active Tasks for invalid project")]
		public void Test_Rest_Tasks_FetchACtiveForInvalidProject()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.GetActiveTasksForProjectAsync("1");
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get All Active Tasks for section")]
		public void Test_Rest_Tasks_FetchActiveTasksForSection()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var tasks = await _client.GetActiveTasksForSectionAsync(TEST_SECTION_ID);

				Assert.Multiple(() =>
				{
					Assert.That(tasks, Is.Not.Null);
					Assert.That(tasks, Has.Count.GreaterThan(0));
					Assert.That(tasks.Any(task => task.SectionId != TEST_SECTION_ID), Is.False);
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get All Active Tasks for invalid section")]
		public void Test_Rest_Tasks_FetchActiveForInvalidSection()
		{
            Assert.DoesNotThrowAsync(async () =>
            {
                var tasks = await _client.GetActiveTasksForSectionAsync("1");

                Assert.Multiple(() =>
                {
                    Assert.That(tasks, Is.Not.Null);
                    Assert.That(tasks, Has.Count.EqualTo(0));
                });
            });
        }

		[Test(
			Author = "Demarbit BV",
			Description = "Get All Active Tasks for label")]
		public void Test_Rest_Tasks_FetchActivetasksForLabel()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var tasks = await _client.GetActiveTasksForLabelAsync(TEST_LABEL_NAME);

				Assert.Multiple(() =>
				{
					Assert.That(tasks, Is.Not.Null);
					Assert.That(tasks, Has.Count.GreaterThan(0));
					Assert.That(tasks.Any(task => !task.Labels.Any(l => l == TEST_LABEL_NAME)), Is.False);
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get All Active tasks for invalid label")]
		public void Test_Rest_Tasks_FetchActiveForInvalidLabel()
		{
            Assert.DoesNotThrowAsync(async () =>
            {
                var tasks = await _client.GetActiveTasksForLabelAsync("invalid");

                Assert.Multiple(() =>
                {
                    Assert.That(tasks, Is.Not.Null);
                    Assert.That(tasks, Has.Count.EqualTo(0));
                });
            });
        }

		[Test(
			Author = "Demarbit BV",
			Description = "Get Active Tasks for Filter")]
		public void Test_Rest_Tasks_FetchActiveForFilter()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var tasks = await _client.GetActiveTasksForFilterAsync($"@{TEST_LABEL_NAME}", TodoistLanguages.English);

				Assert.That(tasks, Is.Not.Null);
				Assert.That(tasks, Has.Count.GreaterThan(0));
				Assert.That(tasks.Any(task => !task.Labels.Any(l => l == TEST_LABEL_NAME)), Is.False);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Get Task by Id")]
		public void Test_Rest_Tasks_FetchTaskById()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var task = await _client.GetTaskByIdAsync(TEST_TASK_ID);

				Assert.Multiple(() =>
				{
					Assert.That(task, Is.Not.Null);
					Assert.That(task.Id, Is.EqualTo(TEST_TASK_ID));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test Create/Update/Delete task")]
		public void Test_Rest_Tasks_CreateUpdateDeleteTask()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				// 1. Create
				var createdTask = await _client.CreateTaskAsync(new CreateTodoistTaskModel
				{
					Content = "Task created from tests",
					ProjectId = TEST_PROJECT_ID
				});

				Assert.Multiple(() =>
				{
					Assert.That(createdTask, Is.Not.Null);
					Assert.That(createdTask.ProjectId, Is.EqualTo(TEST_PROJECT_ID));
				});

				// 2. Update
				var updatedTask = await _client.UpdateTaskAsync(createdTask.Id, new UpdateTodoistTaskModel
				{
					Description = "Updated from tests"
				});

				Assert.Multiple(() =>
				{
					Assert.That(updatedTask, Is.Not.Null);
					Assert.That(updatedTask.Id, Is.EqualTo(createdTask.Id));
					Assert.That(updatedTask.Description, Is.EqualTo("Updated from tests"));
				});

				// 3. Delete
				var taskWasDeleted = await _client.DeleteTaskAsync(createdTask.Id);

				Assert.That(taskWasDeleted);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test close/reopen task")]
		public void Test_Rest_Tasks_CloseReopen()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var task = await _client.GetTaskByIdAsync(TEST_TASK_ID);

				Assert.Multiple(() =>
				{
					Assert.That(task, Is.Not.Null);
					Assert.That(task.IsCompleted, Is.False);
				});

				var taskWasClosed = await _client.CloseTaskAsync(TEST_TASK_ID);

				Assert.That(taskWasClosed);

				task = await _client.GetTaskByIdAsync(TEST_TASK_ID);

                Assert.Multiple(() =>
                {
                    Assert.That(task, Is.Not.Null);
                    Assert.That(task.IsCompleted, Is.True);
                });

				var taskWasReopened = await _client.ReopenTaskAsync(TEST_TASK_ID);

				Assert.That(taskWasReopened);

                task = await _client.GetTaskByIdAsync(TEST_TASK_ID);

                Assert.Multiple(() =>
                {
                    Assert.That(task, Is.Not.Null);
                    Assert.That(task.IsCompleted, Is.False);
                });
            });
		}
    }
}

