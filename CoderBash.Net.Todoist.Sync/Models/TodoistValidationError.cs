namespace CoderBash.Net.Todoist.Sync.Models
{
    public class TodoistValidationError
    {
        public string Command { get; set; } = null!;
        public string Property { get; set; } = null!;
        public string ErrorMessage { get; set; } = null!;

        public TodoistValidationError() { }

        public TodoistValidationError(string command, string property, string errorMessage) 
        {
            Command = command;
            Property = property;
            ErrorMessage = errorMessage;
        }
    }
}
