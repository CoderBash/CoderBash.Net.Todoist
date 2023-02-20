using System;
using CoderBash.Net.Todoist.Common.Exceptions;
using CoderBash.Net.Todoist.Rest.Client;
using CoderBash.Net.Todoist.Rest.Models.Sections;
using CoderBash.Net.Todoist.Tests.Constants;

namespace CoderBash.Net.Todoist.Tests.RestTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Rest.Sections",
		Description = "Todoist sections endpoints tests",
		TestOf = typeof(TodoistClient))]
	public class SectionTests
	{
        private readonly string TEST_PROJECT_ID = TodoistConfiguration.GetTestProjectId();

        private ITodoistClient _client;
		private TodoistSection? _testSection;

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
			Description = "Test fetching all sections from the REST endpoint")]
		[Order(1)]
		public void Test_Rest_Sections_FetchAll()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var sections = await _client.GetAllSectionsAsync();

				Assert.Multiple(() =>
				{
					Assert.That(sections, Is.Not.Null);
					Assert.That(sections, Has.Count.GreaterThan(0));
				});

				_testSection = sections[0];
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test fetching all sections for an existing project")]
		[Order(2)]
		public void Test_Rest_Sections_FetchForExistingProject()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var sections = await _client.GetAllSectionsAsync(projectId: TEST_PROJECT_ID);

				Assert.That(sections, Is.Not.Null);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test fetching all sections for non-existing project")]
		[Order(3)]
		public void Test_Rest_Sections_FetchForNonExistingProject()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.GetAllSectionsAsync(projectId: "-1");
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test fetch section by valid ID")]
        [Order(4)]
        public void Test_Rest_Sections_FetchByValidId()
		{
			Assert.That(_testSection, Is.Not.Null);

			Assert.DoesNotThrowAsync(async () =>
			{
				var fetched = await _client.GetSectionByIdAsync(_testSection.Id);

				Assert.Multiple(() =>
				{
					Assert.That(fetched, Is.Not.Null);
					Assert.That(fetched.Id, Is.EqualTo(_testSection.Id));
					Assert.That(fetched.Name, Is.EqualTo(_testSection.Name));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test fetch section by invalid ID")]
        [Order(5)]
        public void Test_Rest_Sections_FetchByInvalidId()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.GetSectionByIdAsync("-1");
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test create/update/delete valid section")]
        [Order(6)]
        public void Test_Rest_Sections_ValidCreateUpdateDelete()
		{
            var testSectionName = "CNTTestSection";
			var updatedSectionName = "CNTTestSectionUpdated";

            Assert.DoesNotThrowAsync(async () =>
			{
				// 1. Create
				var createdSection = await _client.CreateSectionAsync(new CreateTodoistSectionModel
				{
					Name = testSectionName,
					ProjectId = TEST_PROJECT_ID
				});

				Assert.Multiple(() =>
				{
					Assert.That(createdSection, Is.Not.Null);
					Assert.That(createdSection.Name, Is.EqualTo(testSectionName));
				});

				// 2. Update
				var updatedSection = await _client.UpdateSectionAsync(createdSection.Id, new UpdateTodoistSectionModel
				{
					Name = updatedSectionName
				});

				Assert.Multiple(() =>
				{
					Assert.That(updatedSection, Is.Not.Null);
					Assert.That(updatedSection.Name, Is.EqualTo(updatedSectionName));
					Assert.That(updatedSection.Id, Is.EqualTo(createdSection.Id));
				});

				// 3. Delete
				var sectionWasDeleted = await _client.DeleteSectionAsync(updatedSection.Id);

				Assert.That(sectionWasDeleted, Is.True);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test create section with empty name")]
        [Order(7)]
        public void Test_Rest_Sections_TestCreateWithEmptyName()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.CreateSectionAsync(new CreateTodoistSectionModel
				{
					Name = "",
					ProjectId = TEST_PROJECT_ID
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test create section for invalid project")]
        [Order(8)]
        public void Test_Rest_Sections_CreateForInvalidProject()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.CreateSectionAsync(new CreateTodoistSectionModel
				{
					Name = "RandomTestSection",
					ProjectId = "-1"
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test update section with invalid id")]
        [Order(9)]
        public void Test_Rest_Sections_UpdateWithInvalidId()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.UpdateSectionAsync("-1", new UpdateTodoistSectionModel
				{
					Name = "RandomTestSection"
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test delete section with invalid id")]
        [Order(10)]
        public void Test_Rest_Sections_DeleteWithInvalidId()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var sectionWasDeleted = await _client.DeleteSectionAsync("-1");

				Assert.That(sectionWasDeleted, Is.False);
			});
		}
	}
}

