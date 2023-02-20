using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.Serialization;

namespace CoderBash.Net.Todoist.Common.Exceptions
{
    [ExcludeFromCodeCoverage]
	[Serializable]
	public class TodoistException : Exception
	{
		public TodoistException()
		{
		}

        public TodoistException(string? message) : base(message)
        {
        }

        public TodoistException(string? message, Exception? innerException) : base(message, innerException)
        {
        }

        protected TodoistException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}

