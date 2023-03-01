using System.Reflection;

namespace CoderBash.Net.Todoist.Sync.Extensions
{
    internal static class ObjectExtensions
    {
        public static bool IsObjectEmpty(this object obj, string[]? propertyNamesToSkip = null)
        {
            if (obj is null)
            {
                return true;
            }

            var properties = obj.GetType().GetProperties();

            if (propertyNamesToSkip != null) 
            {
                properties = properties.Where(p => !propertyNamesToSkip.Contains(p.Name)).ToArray();
            }

            return properties.All(x => IsNullOrEmpty(x.GetValue(obj)));
        }

        private static bool IsNullOrEmpty(object? value)
        {
            if (value is null) 
                return true;

            if (value.GetType().GetTypeInfo().IsClass)
                return value.IsObjectEmpty();

            if (value is string || value is char || value is short)
                return string.IsNullOrEmpty((string)value);

            if (value is not null)
                return value.IsObjectEmpty();

            return false;
        }
    }
}
