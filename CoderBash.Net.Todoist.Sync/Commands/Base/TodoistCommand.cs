using CoderBash.Net.Todoist.Common.Extensions;
using CoderBash.Net.Todoist.Sync.Models;
using Newtonsoft.Json;

namespace CoderBash.Net.Todoist.Sync.Commands.Base
{
    public abstract class TodoistCommand
    {
        private readonly string _commandUniqueId = Guid.NewGuid().ToString();

        protected string? _temporaryId;

        protected abstract string CommandType { get; }
        protected abstract Dictionary<string, object> GetCommandArgs();

        internal abstract bool ValidateCommand(out List<TodoistValidationError> errors);

        internal string GenerateCommand()
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
