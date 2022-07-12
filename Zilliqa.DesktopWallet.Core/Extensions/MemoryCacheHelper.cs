using System;
using System.Runtime.Caching;
using System.Threading.Tasks;

namespace Zilliqa.DesktopWallet.Core.Extensions
{
    public static class MemoryCacheHelper
    {
        public static Task<T> GetSetCacheAsync<T>(string key, Func<Task<T>> loadFunction)
        {
            return GetSetCacheAsync(key, DateTimeOffset.MaxValue, loadFunction);
        }

        public static async Task<T> GetSetCacheAsync<T>(string key, DateTimeOffset absoluteExpiration, Func<Task<T>> loadFunction)
        {
            ObjectCache cache = MemoryCache.Default;
            T val = (T)cache.Get(key);
            if (val == null)
            {
                val = await loadFunction.Invoke();
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = absoluteExpiration;
                if (val != null)
                {
                    cache.Add(key, val, policy);
                }
            }
            return val;
        }

        public static T GetSetCache<T>(string key, Func<T> loadFunction)
        {
            return GetSetCache(key, DateTimeOffset.MaxValue, loadFunction);
        }

        public static T GetSetCache<T>(string key, DateTimeOffset absoluteExpiration, Func<T> loadFunction)
        {
            ObjectCache cache = MemoryCache.Default;
            T val = (T)cache.Get(key);
            if (val == null)
            {
                val = loadFunction.Invoke();
                CacheItemPolicy policy = new CacheItemPolicy();
                policy.AbsoluteExpiration = absoluteExpiration;
                if (val != null)
                {
                    cache.Add(key, val, policy);
                }
            }
            return val;
        }

        public static void RemoveCache(string key)
        {
            ObjectCache cache = MemoryCache.Default;
            cache.Remove(key);
        }

    }
}
