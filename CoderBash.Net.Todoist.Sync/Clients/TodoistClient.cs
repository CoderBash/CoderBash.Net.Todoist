using CoderBash.Net.Todoist.Common.Exceptions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Clients
{
    public partial interface ITodoistClient : IDisposable
    {

    }

    public sealed partial class TodoistClient : ITodoistClient
    {
        private readonly HttpClient _client;

        public TodoistClient(string apiToken)
        {
            _client = SetupClient(apiToken);
        }

        #region HTTP Handlers
        private async Task<TResult> PostFormAsync<TResult>(string endpoint, IEnumerable<KeyValuePair<string, string>> parameters, CancellationToken cancellationToken =  default)
        {
            using var formData = new FormUrlEncodedContent(parameters);

            var response = await _client.PostAsync(endpoint, formData, cancellationToken);

            if (!response.IsSuccessStatusCode)
            {
                throw new TodoistException($"{GetResponseErrorInfo(response)} returned an error: {response.ReasonPhrase}");
            }

            var responseContent = await response.Content.ReadAsStringAsync(cancellationToken) ?? throw new TodoistException($"Unable to read content of {GetResponseErrorInfo(response)}");
            var responseModel = JsonConvert.DeserializeObject<TResult>(responseContent) ?? throw new TodoistException($"Unable to deserialize {typeof(TResult).Name} model from the contents of {GetResponseErrorInfo(response)}");

            return responseModel;
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
                BaseAddress = new Uri("https://api.todoist.com/sync/v9/")
            };

            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", apiToken);

            return client;
        }
        #endregion
    }
}
