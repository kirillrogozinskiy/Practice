using System.Collections.Generic;
using System.Linq;
using WatchList.Models;

namespace WatchList.Services
{
    public class WatchlistService : IWatchlistService
    {
        private static List<WatchItem> _watchItems = new List<WatchItem>();
        private static int _nextId = 1;

        public void AddItem(WatchItem item)
        {
            item.Id = _nextId++;
            item.Status = "К просмотру";
            _watchItems.Add(item);
        }

        public void RemoveItem(int id)
        {
            var item = _watchItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                _watchItems.Remove(item);
            }
        }

        public IEnumerable<WatchItem> GetAllItems()
        {
            return _watchItems;
        }

        public WatchItem GetItemById(int id)
        {
            return _watchItems.FirstOrDefault(x => x.Id == id);
        }

        public void MarkAsWatched(int id)
        {
            var item = _watchItems.FirstOrDefault(x => x.Id == id);
            if (item != null)
            {
                item.Status = "Просмотрено";
            }
        }

        public IEnumerable<WatchItem> GetItemsByStatus(string status)
        {
            return _watchItems.Where(x => x.Status == status).ToList();
        }
    }
}