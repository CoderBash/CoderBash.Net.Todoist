using System;
using System.Xml.Linq;
using CoderBash.Net.Todoist.Common.Enums;
using CoderBash.Net.Todoist.Common.Exceptions;
using CoderBash.Net.Todoist.Rest.Client;
using CoderBash.Net.Todoist.Rest.Models.Projects;
using CoderBash.Net.Todoist.Tests.Constants;

namespace CoderBash.Net.Todoist.Tests.RestTests
{
	[TestFixture(
		Author = "Demarbit BV",
		Category = "Todoist.Rest.Projects",
		Description = "Todoist projects endpoints tests",
		TestOf = typeof(TodoistClient))]
	public class ProjectTests
	{
		private ITodoistClient _client;
		private TodoistProject? _testProject;

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
			Description = "Test fetching all projects from the REST endpoint.")]
		[Order(1)]
		public void Test_Rest_Projects_FetchAll()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var projects = await _client.GetProjectsAsync();

				Assert.Multiple(() =>
				{
					Assert.That(projects, Is.Not.Null);
					Assert.That(projects, Has.Count.GreaterThan(0));
				});

				_testProject = projects[0];
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test fetching a single project by id from the REST endpoint.")]
		[Order(2)]
		public void Test_Rest_Projects_FetchById()
		{
			Assert.That(_testProject, Is.Not.Null, "Test project fetched during 1st test case was invalid.");

			Assert.DoesNotThrowAsync(async () =>
			{				
				var fetchedProject = await _client.GetProjectByIdAsync(_testProject.Id);

				Assert.Multiple(() =>
				{
					Assert.That(fetchedProject, Is.Not.Null);
					Assert.That(fetchedProject.Name, Is.EqualTo(_testProject.Name));
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test fetching project's collaborators from the REST endpoint.")]
		[Order(3)]
		public void Test_Rest_Projects_GetCollaborators()
		{
			Assert.That(_testProject, Is.Not.Null, "Test project fetched during 1st test case was invalid.");

			Assert.DoesNotThrowAsync(async () =>
			{
				var collaborators = await _client.GetProjectCollaboratorsAsync(_testProject.Id);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test create, update and delete of random project for the REST endpoint.")]
		[Order(4)]
		public void Test_Rest_Projects_CreateUpdateDelete()
		{
			var testProjectName = "CNTTestProject";

			Assert.DoesNotThrowAsync(async () =>
			{
				// 1. Create
				var createdProject = await _client.CreateProjectAsync(new CreateTodoistProjectModel
				{
					Name = testProjectName
				});

				Assert.Multiple(() =>
				{
					Assert.That(createdProject, Is.Not.Null);
					Assert.That(createdProject.Name, Is.EqualTo(testProjectName));
				});

				// 2. Update
				var updatedProject = await _client.UpdateProjectAsync(createdProject.Id, new UpdateTodoistProjectModel
				{
					Color = TodoistColors.BerryRed
				});

				Assert.Multiple(() =>
				{
					Assert.That(updatedProject, Is.Not.Null);
					Assert.That(updatedProject.Name, Is.EqualTo(testProjectName));
					Assert.That(updatedProject.Id, Is.EqualTo(createdProject.Id));
					Assert.That(updatedProject.Color, Is.EqualTo("berry_red"));
				});

				// 3. Delete
				var wasProjectDeleted = await _client.DeleteProjectAsync(updatedProject.Id);

				Assert.That(wasProjectDeleted, Is.True);
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test create with empty name")]
        [Order(5)]
        public void Test_Rest_Projects_CreateWithEmptyName()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.CreateProjectAsync(new CreateTodoistProjectModel
				{
					Name = ""
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test update with invalid ID")]
        [Order(6)]
        public void Test_Rest_Projects_UpdateWithINvalidID()
		{
			Assert.ThrowsAsync<TodoistException>(async () =>
			{
				await _client.UpdateProjectAsync("-1", new UpdateTodoistProjectModel
				{
					Name = "RandomProjectUpdate"
				});
			});
		}

		[Test(
			Author = "Demarbit BV",
			Description = "Test delete with invalid ID")]
        [Order(7)]
        public void Test_Rest_Projects_DeleteWithInvalidID()
		{
			Assert.DoesNotThrowAsync(async () =>
			{
				var projectWasDeleted = await _client.DeleteProjectAsync("-1");

				Assert.That(projectWasDeleted, Is.False);
			});
		}
	}
}

