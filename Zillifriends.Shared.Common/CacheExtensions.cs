using System.Diagnostics;
using System.Runtime.Caching;

namespace Zillifriends.Shared.Common
{
    public static class CacheExtensions
    {
        public static bool TryGet<TResult>(this ObjectCache cache, string key, out TResult result)
        {
            if (cache.Contains(key))
            {
                result = (TResult)cache[key];
                return true;
            }

            result = default(TResult)!;
            return false;
        }

        public static TResult? GetOrAdd<TResult>(this ObjectCache cache, string key, TimeSpan expiration, Func<TResult> valueFactory)
        {
            if (cache.Contains(key))
            {
                return (TResult) cache[key];
            }
            try
            {
                var value = valueFactory.Invoke();
                if (value != null)
                {
                    cache.Add(key, value, DateTimeOffset.Now + expiration);
                }
                return value;
            }
            catch (Exception e)
            {
                // TODO: Logging
                Debug.WriteLine(e);
            }

            return default(TResult);
        }

        public static TResult? GetOrAdd<TResult>(this ObjectCache cache, string key, TimeSpan expiration, Func<TResult> valueFactory, object syncLock)
        {
            if (cache.Contains(key))
            {
                return (TResult)cache[key];
            }

            lock (syncLock)
            {
                if (cache.Contains(key))
                {
                    return (TResult)cache[key];
                }
                try
                {
                    var value = valueFactory.Invoke();
                    if (value != null)
                    {
                        cache.Add(key, value, DateTimeOffset.Now + expiration);
                    }
                    return value;
                }
                catch (Exception e)
                {
                    // TODO: Logging
                    Debug.WriteLine(e);
                }

                return default(TResult);
            }
        }
    }
}
