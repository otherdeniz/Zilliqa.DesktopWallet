using System.Runtime.Caching;

namespace Zillifriends.Shared.Common
{
    public static class CacheExtensions
    {
        public static TResult GetOrAdd<TResult>(this ObjectCache cache, string key, TimeSpan expiration, Func<TResult> valueFactory)
        {
            if (cache.Contains(key))
            {
                return (TResult) cache[key];
            }
            var value = valueFactory.Invoke();
            cache.Add(key, value, DateTimeOffset.Now + expiration);
            return value;
        }
    }
}
