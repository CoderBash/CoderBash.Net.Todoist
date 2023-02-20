using System;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Exceptions;
using CoderBash.Net.Todoist.Rest.Client;
using CoderBash.Net.Todoist.Rest.Models.Labels;
using CoderBash.Net.Todoist.Tests.Constants;

namespace CoderBash.Net.Todoist.Tests.RestTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Rest.Labels",
		Description = "Labels REST endpoint tests",
		TestOf = typeof(TodoistClient))]
	public class LabelTests
	{
		private readonly string TEST_LABEL_ID = TodoistConfiguration.GetTestLabelId();

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
			Description = "Test fetch labels")]
		public void Test_Rest_Labels_FetchLabels()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var labels = await _client.GetLabelsAsync();

				Assert.Multiple(() =>
				{
					Assert.That(labels, Is.Not.Null);
					Assert.That(labels, Has.Count.GreaterThan(0));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test fetch valid label")]
		public void Test_Rest_Labels_FetchValidLabel()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var label = await _client.GetLabelAsync(TEST_LABEL_ID);

				Assert.Multiple(() =>
				{
					Assert.That(label, Is.Not.Null);
					Assert.That(label.Id, Is.EqualTo(TEST_LABEL_ID));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test fetch invalid label")]
		public void Test_Rest_Labels_FetchInvalidLabel()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.GetLabelAsync("-1");
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test Create/Update/Delete label")]
		public void Test_Rest_Labels_CreateUpdateDelete()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var createdLabel = await _client.CreateLabelAsync(new CreateTodoistLabelModel
				{
					Color = TodoistColors.LimeGreen,
					IsFavorite = true,
					Name = "created-by-tests"
				});

				Assert.Multiple(() =>
				{
					Assert.That(createdLabel, Is.Not.Null);
					Assert.That(createdLabel.Name, Is.EqualTo("created-by-tests"));
					Assert.That(createdLabel.Color, Is.EqualTo(TodoistColorsUtils.GetColorKey(TodoistColors.LimeGreen)));
				});

				var updatedLabel = await _client.UpdateLabelAsync(createdLabel.Id, new UpdateTodoistLabelModel
				{
					Color = TodoistColors.Taupe,
					Name = "updated-by-tests"
				});

				Assert.Multiple(() =>
				{
					Assert.That(updatedLabel, Is.Not.Null);
					Assert.That(updatedLabel.Id, Is.EqualTo(createdLabel.Id));
					Assert.That(updatedLabel.Name, Is.EqualTo("updated-by-tests"));
					Assert.That(updatedLabel.Color, Is.EqualTo(TodoistColorsUtils.GetColorKey(TodoistColors.Taupe)));
				});

				var labelWasDeleted = await _client.DeleteLabelAsync(updatedLabel.Id);

				Assert.That(labelWasDeleted, Is.True);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test create invalid label")]
		public void Test_Rest_Labels_CreateInvalidLabel()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.CreateLabelAsync(new CreateTodoistLabelModel
				{
					Name = ""
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test update invalid label")]
		public void Test_Rest_Labels_UpdateInvalidLabel()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.UpdateLabelAsync("-1", new UpdateTodoistLabelModel
				{
					Name = "random-label"
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test delete invalid label")]
		public void Test_Rest_Labels_DeleteInvalidLabel()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var labelWasRemoved = await _client.DeleteLabelAsync("-1");

				Assert.That(labelWasRemoved, Is.False);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test get shared labels")]
		public void Test_Rest_Labels_GetSharedLabels()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var sharedLabelsIncludingPersonal = await _client.GetSharedLabelsAsync();

				Assert.Multiple(() =>
				{
					Assert.That(sharedLabelsIncludingPersonal, Is.Not.Null);
					Assert.That(sharedLabelsIncludingPersonal, Has.Length.GreaterThan(0));
				});

				var sharedLabelsExcludingPersonal = await _client.GetSharedLabelsAsync(omitPersonalLabels: true);

				Assert.Multiple(() =>
				{
					Assert.That(sharedLabelsExcludingPersonal, Is.Not.Null);
					Assert.That(sharedLabelsExcludingPersonal, Has.Length.GreaterThanOrEqualTo(0));
					Assert.That(sharedLabelsExcludingPersonal, Has.Length.LessThan(sharedLabelsIncludingPersonal.Length));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test rename shared label")]
		public void Test_Rest_Labels_RenameShared()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var sharedLabels = await _client.GetSharedLabelsAsync(omitPersonalLabels: true);

				Assert.That(sharedLabels, Is.Not.Null);

				if (sharedLabels.Length == 0)
					return;

				var labelRenamed = await _client.RenameSharedLabelAsync(sharedLabels[0], $"label-{DateTime.Now:yyyyMMddHHmmss}");

				Assert.That(labelRenamed, Is.True);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test remove shared label")]
		public void Test_Rest_Labels_RemoveShared()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var labelRemoved = await _client.RemoveSharedLabelAsync("shared-label");

				Assert.That(labelRemoved, Is.True);
			});
		}
	}
}

