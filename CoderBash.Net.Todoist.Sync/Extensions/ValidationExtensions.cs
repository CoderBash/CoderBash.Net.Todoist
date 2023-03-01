using CoderBash.Net.Todoist.Sync.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CoderBash.Net.Todoist.Sync.Extensions
{
    internal static class ValidationExtensions
    {
        internal static TodoistValidationError GetRequiredFieldError<TClass>(this TClass obj, string fieldName) where TClass : class
        {
            return new TodoistValidationError(obj.GetType().Name, fieldName, $"{fieldName} is required.");
        }
    }
}
