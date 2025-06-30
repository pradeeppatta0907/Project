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
        public async Task<List<string>> InitializeList(IEnumerable<string> items)
        {
            if (items == null) throw new ArgumentNullException(nameof(items));

            var bag = new ConcurrentBag<string>();
            await Parallel.ForEachAsync(items, async (item, _) =>
            {
                // simulate async work; replace Task.FromResult with real async logic if needed
                var result = await Task.FromResult(item).ConfigureAwait(false);
                bag.Add(result);
            }).ConfigureAwait(false);

            return bag.ToList();
        }


        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            if (getItem == null) throw new ArgumentNullException(nameof(getItem));

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