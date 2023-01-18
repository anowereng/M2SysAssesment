namespace M2SysAssesment.Services.Common.Extensions
{
    public static class IEnumerableExtensions
    {
        public static bool AreAnyDuplicates<T>(this IEnumerable<T> list)
        {
            var hashset = new HashSet<T>();
            return list.Any(e => !hashset.Add(e));
        }
        public static bool IsNullOrEmpty<T>(this IEnumerable<T> list)
        {
            return list == null || list.Count() <= 0;
        }
    }
}
