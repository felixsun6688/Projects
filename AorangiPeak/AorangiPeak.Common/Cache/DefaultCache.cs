﻿using AorangiPeak.Common.Setting;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web;
using System.Web.Caching;

namespace AorangiPeak.Common.Cache
{
    public class DefaultCache : ICache
    {
        private static System.Web.Caching.Cache cache;

        private TimeSpan _timeSpan = new TimeSpan(
                Settings.DefaultCacheDuration_Days,
                Settings.DefaultCacheDuration_Hours,
                Settings.DefaultCacheDuration_Minutes,
                Settings.DefaultCacheDuration_Seconds
            );

        static DefaultCache()
        {
            cache = HttpContext.Current.Cache;
        }

        public object Get(string cache_key)
        {
            return cache.Get(cache_key);
        }

        public List<string> GetCacheKeys()
        {
            List<string> keys = new List<string>();
            IDictionaryEnumerator ca = cache.GetEnumerator();
            while (ca.MoveNext())
            {
                keys.Add(ca.Key.ToString());
            }

            return keys;
        }

        public void Set(string cache_key, object cache_object)
        {
            Set(cache_key, cache_object, _timeSpan);
        }

        public void Set(string cache_key, object cache_object, TimeSpan expiration)
        {
            Set(cache_key, cache_object, expiration, CacheItemPriority.Normal);
        }

        public void Set(string cache_key, object cache_object, DateTime expiration)
        {
            Set(cache_key,  cache_object, expiration, CacheItemPriority.Normal);
        }

        public void Set(string cache_key, object cache_object, DateTime expiration, 
                               CacheItemPriority priority)
        {
            cache.Insert(cache_key, cache_object, null, expiration, 
                System.Web.Caching.Cache.NoSlidingExpiration, priority,  null);
        }

        public void Set(string cache_key, object cache_object, TimeSpan expiration,
                               CacheItemPriority priority)
        {
            cache.Insert(cache_key, cache_object, null,
                System.Web.Caching.Cache.NoAbsoluteExpiration, expiration, priority, null);
        }

        public void Delete(string cache_key)
        {
            if (Exists(cache_key))
                cache.Remove(cache_key);
        }

        public bool Exists(string cache_key)
        {
            if (cache[cache_key] != null)
                return true;
            else
                return false;
        }

        public void Flush()
        {
            foreach (string key in GetCacheKeys())
            {
                Delete(key);
            }
        }
    }
}
