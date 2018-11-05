using System;
using System.Collections.Concurrent;
using System.Linq;

namespace DbConfiguration
{
    public class RemoteOptionsEntity
    {
        private ConcurrentDictionary<string, Type> ConCurrentDictionary = new ConcurrentDictionary<string, Type>();

        public void Add<TEntity>(string Key) where TEntity : class
        {
            if (ContainsKey(Key))
            {
                ConCurrentDictionary[Key] = typeof(TEntity);
            }
            else
            {
                ConCurrentDictionary.TryAdd(Key, typeof(TEntity));
            }
        }

        public bool ContainsKey(string Key)
        {
            return ConCurrentDictionary.ContainsKey(Key);
        }

        public string GetKey<TEntity>()
        {
            return ConCurrentDictionary.FirstOrDefault(item => item.Value == typeof(TEntity)).Key;
        }
    }
}
