using CoderBash.Net.Todoist.Common.Extensions;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Sync.Commands.Base
{
    public abstract class TodoistCommand
    {
        private readonly string _commandUniqueId = Guid.NewGuid().ToString();
        public string CommandUniqueId => _commandUniqueId;

        protected string? _temporaryId;
        public string CommandTemporaryId => _temporaryId ?? "";

        protected abstract string CommandType { get; }
        protected abstract Dictionary<string, object> GetCommandArgs();

        public string GenerateCommand()
        {
            var commandObject = new Dictionary<string, object>()
            {
                ["type"] = CommandType,
                ["uuid"] = _commandUniqueId,
                ["args"] = GetCommandArgs()
            };

            commandObject.TryAddValue("temp_id", _temporaryId);

            return JsonConvert.SerializeObject(commandObject);
        }
    }
}
