namespace CoderBash.Net.Todoist.Common.Extensions
{
    public static class ListExtensions
    {
        public static bool None<TEntity>(this List<TEntity> list) where TEntity : class
        {
            return !list.Any();
        }
    }
}
