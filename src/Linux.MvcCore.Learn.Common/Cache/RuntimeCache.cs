using Linux.MvcCore.Learn.Common.Cache;
using Microsoft.Extensions.Caching.Memory;
using System;

namespace Linux.MvcCore.Learn.Common
{
    /// <summary>
    /// the runtime momery Cache class
    /// </summary>
    public class RuntimeCache : ICache
    {

        private readonly MemoryCache _cache;
        private readonly MemoryCacheEntryOptions _defaultCacheItemPolicy;

        public RuntimeCache()
        {
            _cache = new MemoryCache(new CacheOption()); 
            _defaultCacheItemPolicy = new MemoryCacheEntryOptions().SetSlidingExpiration(TimeSpan.FromSeconds(60 * 2));
        }

        /// <summary>
        /// get the cache property
        /// </summary>
        /// <param name="AbsoluteExpirationTimeSpan"> set the Absolute Expiration TimeSpan</param>
        /// <param name="SlidingExpirationTimeSpan">set the Sliding Expiration TimeSpan</param>
        /// <param name="delgate">the call back delegate the type is PostEvictionDelegate</param>
        /// <returns></returns>
        private static MemoryCacheEntryOptions GetCacheEntryOptions(TimeSpan AbsoluteExpirationTimeSpan, TimeSpan SlidingExpirationTimeSpan, PostEvictionDelegate delgate)
        {
            return new MemoryCacheEntryOptions()
                .SetAbsoluteExpiration(AbsoluteExpirationTimeSpan)
                .SetSlidingExpiration(SlidingExpirationTimeSpan)
                .RegisterPostEvictionCallback(delgate != null ? delgate : AfterEvicted, state: null); //();
        }



        /// <summary>
        /// the auto delete cache callback
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="value">the cache Object</param>
        /// <param name="reason">remove reason</param>
        /// <param name="state">the state</param>
        private static void AfterEvicted(object key, object value, EvictionReason reason, object state)
        {
            Console.WriteLine("Evicted. Value: " + value + ", Reason: " + reason);
        }

        /// <summary>
        /// add cache  use de default MemoryCacheEntryOptions
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="obj">the cache Object</param>
        public void Add(string key, object obj)
        {
            _cache.Set(key, obj, _defaultCacheItemPolicy);
        }

        /// <summary>
        /// add cache 
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="obj">the cache Object</param>
        /// <param name="seconds">cache time</param>
        public void Add(string key, object obj, int seconds)
        {
            _cache.Set(key, obj, DateTimeOffset.Now.AddSeconds(seconds));

        }

        /// <summary>
        /// add cache 
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="obj">the cache Object</param>
        /// <param name="slidingExpiration">the dynamic Cache time span</param>
        public void Add(string key, object obj, TimeSpan slidingExpiration)
        {
            var cacheItemPolicy = new MemoryCacheEntryOptions().SetSlidingExpiration(slidingExpiration);  
            _cache.Set(key, obj, cacheItemPolicy);
        }

        /// <summary>
        /// get the key whether in the cache
        /// </summary>
        /// <param name="key">the key</param>
        /// <returns>Exists True ,else false </returns>
        public bool Exists(string key)
        {
            return _cache.Get(key) != null;
        }

        /// <summary>
        /// get the cache object use the cache key
        /// </summary>
        /// <typeparam name="T">the Template</typeparam>
        /// <param name="key">the key</param>
        /// <returns>the object</returns>
        public T Get<T>(string key)
        {
            return (T)_cache.Get(key);
        }

        /// <summary>
        ///  add the cache never remove
        /// </summary>
        /// <param name="key">the key</param>
        /// <param name="obj">the cache object</param>
        public void Max(string key, object obj)
        {

            var cacheItemPolicy = new MemoryCacheEntryOptions().SetAbsoluteExpiration(DateTime.MaxValue.AddYears(-1)).SetPriority(CacheItemPriority.NeverRemove);
            _cache.Set(key, obj, cacheItemPolicy);
        }

        /// <summary>
        /// remove the cache from the cache
        /// </summary>
        /// <param name="key">the cache key</param>
        public void Remove(string key)
        {
            _cache.Remove(key);
        }

        public bool Test()
        {
            const string key = "_##**Test**##_";
            const string obj = "Test";
            Add(key, obj);
            var result = Get<string>(key);
            return result == obj;
        }
    }
}