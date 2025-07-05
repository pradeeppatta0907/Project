using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {

       // Runs synchronous work in parallel no async needed since there’s no I/O or async calls.
        
       public List<string> InitializeList(IEnumerable<string> items)
       {
           ArgumentNullException.ThrowIfNull(items);

           var bag = new ConcurrentBag<string>();

           Parallel.ForEach(items, bag.Add);

          return bag.ToList();
       }

        

        // Runs synchronous initialization in parallel using a synchronous getItem function.
        // async/await is not used because getItem is not asynchronous.
        
        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            ArgumentNullException.ThrowIfNull(getItem);

            var items = Enumerable.Range(0, 100);
            var dict = new ConcurrentDictionary<int, string>();

            Parallel.ForEach(items, item =>
            {
                dict.TryAdd(item, getItem(item));
            });

            return dict.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}
