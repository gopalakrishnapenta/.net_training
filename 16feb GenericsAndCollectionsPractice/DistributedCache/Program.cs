using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Challenge3_DistributedCache
{
    public class DistributedCache<TKey, TValue>
        where TKey : IEquatable<TKey>
        where TValue : class
    {
        private SortedDictionary<uint, string> _hashRing = new();
        private ConcurrentDictionary<TKey, TValue> _localCache = new();

        private uint Hash(TKey key)
            => (uint)key.GetHashCode();

        public Task<bool> SetAsync(TKey key, TValue value)
        {
            _localCache[key] = value;
            return Task.FromResult(true);
        }

        public Task<TValue> GetAsync(TKey key)
        {
            _localCache.TryGetValue(key, out var value);
            return Task.FromResult(value);
        }

        public void AddNode(string nodeId)
        {
            _hashRing[(uint)nodeId.GetHashCode()] = nodeId;
        }
    }

    class Program
    {
        static async Task Main()
        {
            var cache = new DistributedCache<string, string>();
            cache.AddNode("NodeA");

            await cache.SetAsync("user1", "Gopi");
            var result = await cache.GetAsync("user1");

            Console.WriteLine(result);
        }
    }
}
