using System;
using System.Net.Http.Headers;
using System.Text;
using CoderBash.Net.Todoist.Common.Exceptions;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Rest.Client
{
	public partial interface ITodoistClient : IDisposable
	{

	}

	public sealed partial class TodoistClient : ITodoistClient
	{
		private const string API_ENDPOINT = "";

		private readonly HttpClient _client;

		public TodoistClient(string apiToken)
		{
			_client = SetupClient(apiToken);
		}

        #region HTTP Handlers
		private async Task<bool> DeleteAsync(string endpoint, CancellationToken cancellationToken = default)
		{
			var response = await _client.DeleteAsync(endpoint, cancellationToken);
			return response.IsSuccessStatusCode;
		}

		private async Task<TResponse> GetAsync<TResponse>(string endpoint, CancellationToken cancellationToken = default)
		{
			var response = await _client.GetAsync(endpoint, cancellationToken);
			return await GetModelFromResponseAsync<TResponse>(response, cancellationToken);
		}

		private async Task<bool> PostAsync(string endpoint, object? body = null, CancellationToken cancellationToken = default)
		{
			var requestContent = body != null ? GetRequestContent(body) : null;

			var response = await _client.PostAsync(endpoint, requestContent, cancellationToken);
			return response.IsSuccessStatusCode;
		}

		private async Task<TResponse> PostAsync<TResponse>(string endpoint, object body, CancellationToken cancellationToken = default)
		{
			var requestContent = GetRequestContent(body);
			var response = await _client.PostAsync(endpoint, requestContent, cancellationToken);
			return await GetModelFromResponseAsync<TResponse>(response, cancellationToken);
		}

		private static async Task<TResponse> GetModelFromResponseAsync<TResponse>(HttpResponseMessage response, CancellationToken cancellationToken = default)
		{
			if (!response.IsSuccessStatusCode)
			{
				throw new TodoistException($"{GetResponseErrorInfo(response)} returned an error: {response.ReasonPhrase}");
			}

			var responseContent = await response.Content.ReadAsStringAsync(cancellationToken) ?? throw new TodoistException($"Unable to read content of {GetResponseErrorInfo(response)}");
            var responseModel = JsonConvert.DeserializeObject<TResponse>(responseContent) ?? throw new TodoistException($"Unable to deserialize {typeof(TResponse).Name} model from the contents of {GetResponseErrorInfo(response)}");
            
			return responseModel;
		}

		private static StringContent GetRequestContent(object body)
		{
			return new StringContent(JsonConvert.SerializeObject(body), Encoding.UTF8, "application/json");
		}

		private static string GetResponseErrorInfo(HttpResponseMessage response)
		{
			return response.RequestMessage != null
				? $"{response.RequestMessage.Method} request {response.RequestMessage.RequestUri}"
				: "Todoist request";
		}
        #endregion

        #region Disposable implementation
        public void Dispose()
        {
			GC.SuppressFinalize(this);

			_client?.Dispose();
        }
		#endregion

		#region Setup implementation
		private static HttpClient SetupClient(string apiToken)
		{
			var client = new HttpClient()
			{
				BaseAddress = new Uri("https://api.todoist.com/rest/v2/")
			};

			client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

			return client;
		}
		#endregion
	}
}

