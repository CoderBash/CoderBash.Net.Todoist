using System;
using CoderBash.Net.Todoist.Common.Exceptions;
using CoderBash.Net.Todoist.Rest.Client;
using CoderBash.Net.Todoist.Rest.Models.Comments;
using CoderBash.Net.Todoist.Tests.Constants;

namespace CoderBash.Net.Todoist.Tests.RestTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Rest.Comments",
		Description = "Comment REST endpoint tsts",
		TestOf = typeof(TodoistClient))]
	public class CommentTests
	{
		private readonly string TEST_PROJECT_ID = TodoistConfiguration.GetTestProjectId();
        private readonly string TEST_TASK_ID = TodoistConfiguration.GetTestTaskId();

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
			Description = "Fetch project comments")]
		public void Test_Rest_Comments_FetchProjectComments()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var comments = await _client.GetProjectCommentsAsync(TEST_PROJECT_ID);

				Assert.Multiple(() =>
				{
					Assert.That(comments, Is.Not.Null);
					Assert.That(comments, Has.Count.GreaterThan(0));
				});

				var testComment = comments[0];

				var fetched = await _client.GetCommentAsync(testComment.Id);

				Assert.Multiple(() =>
				{
					Assert.That(fetched, Is.Not.Null);
					Assert.That(fetched.Id, Is.EqualTo(testComment.Id));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Fetch project comments for invalid project id")]
		public void Test_Rest_Comments_FetchProjectCommentsForInvalidProject()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.GetProjectCommentsAsync("-1");
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Fetch task comments")]
		public void Test_Rest_Comments_FetchTaskComments()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var comments = await _client.GetTaskCommentsAsync(TEST_TASK_ID);

				Assert.Multiple(() =>
				{
					Assert.That(comments, Is.Not.Null);
					Assert.That(comments, Has.Count.GreaterThan(0));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Fetch task comments for invalid task id")]
		public void Test_Rest_Comments_FetchTaskCommentsForInvalidTask()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.GetTaskCommentsAsync("-1");
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Fetch invalid comment")]
		public void Test_Rest_Comments_FetchInvalidComment()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.GetCommentAsync("-1");
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test Add/Update/Delete comment to project")]
		public void Test_Rest_Comments_AddUpdateDeleteProjectComment()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var addedComment = await _client.AddCommentToProjectAsync(new CreateTodoistCommentModel
				{
					Content = "Test #" + Guid.NewGuid(),
					ParentId = TEST_PROJECT_ID
				});

				Assert.Multiple(() =>
				{
					Assert.That(addedComment, Is.Not.Null);
					Assert.That(addedComment.ProjectId, Is.EqualTo(TEST_PROJECT_ID));
					Assert.That(addedComment.TaskId, Is.Null);
				});

				var updatedContent = addedComment + " which has been updated";

                var updatedComment = await _client.UpdateCommentAsync(addedComment.Id, new UpdateTodoistCommentModel
				{
					Content = updatedContent
				});

				Assert.Multiple(() =>
				{
					Assert.That(updatedComment, Is.Not.Null);
					Assert.That(updatedComment.Id, Is.EqualTo(addedComment.Id));
					Assert.That(updatedComment.Content, Is.EqualTo(updatedContent));
				});

				var commentWasRemoved = await _client.DeleteCommentAsync(addedComment.Id);

				Assert.That(commentWasRemoved, Is.True);
			});
		}

        [Test(
            Author = "Demarbit BV",
            Description = "Test Add/Update/Delete comment to task")]
        public void Test_Rest_Comments_AddUpdateDeleteTaskComment()
        {
            Assert.DoesNotThrowAsync(async () =>
            {
                var addedComment = await _client.AddCommentToTaskAsync(new CreateTodoistCommentModel
                {
                    Content = "Test #" + Guid.NewGuid(),
                    ParentId = TEST_TASK_ID
                });

                Assert.Multiple(() =>
                {
                    Assert.That(addedComment, Is.Not.Null);
                    Assert.That(addedComment.TaskId, Is.EqualTo(TEST_TASK_ID));
                    Assert.That(addedComment.ProjectId, Is.Null);
                });

                var updatedContent = addedComment + " which has been updated";

                var updatedComment = await _client.UpdateCommentAsync(addedComment.Id, new UpdateTodoistCommentModel
                {
                    Content = updatedContent
                });

                Assert.Multiple(() =>
                {
                    Assert.That(updatedComment, Is.Not.Null);
                    Assert.That(updatedComment.Id, Is.EqualTo(addedComment.Id));
                    Assert.That(updatedComment.Content, Is.EqualTo(updatedContent));
                });

                var commentWasRemoved = await _client.DeleteCommentAsync(addedComment.Id);

                Assert.That(commentWasRemoved, Is.True);
            });
        }

		[Test(
			Author = "Demarbit BV",
			Description = "Add comment to non-existing project")]
		public void Test_Rest_Comments_AddCommentToNonExistingProject()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.AddCommentToProjectAsync(new CreateTodoistCommentModel
				{
					Content = "Random",
					ParentId = "-1"
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description ="Add comment to non-existing task")]
		public void Test_Rest_Comments_AddCommentToNonExistingTask()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.AddCommentToTaskAsync(new CreateTodoistCommentModel
				{
					Content = "Random",
					ParentId = "-1"
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Update non-existing comment")]
		public void Test_Rest_Comments_UpdateNonExistingComment()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.UpdateCommentAsync("-1", new UpdateTodoistCommentModel { Content = "Random" });
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Delete non-existing comment")]
		public void Test_Rest_Comments_DeleteNonExistingComment()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var commentWasDeleted = await _client.DeleteCommentAsync("-1");

				Assert.That(commentWasDeleted, Is.False);
			});
		}
    }
}

